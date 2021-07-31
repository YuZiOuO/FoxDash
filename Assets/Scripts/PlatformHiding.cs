using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHiding : MonoBehaviour
{
    public float timer;
    public float hidingEnterTime;
    public float hidingTime;
    public float transitTime;
    /*״ָ̬ʾ
     * 0 = ����
     * 1 = ���ض���
     * 2 = ����
     * 3 = ��ʾ����*/
    public int status;
    public SpriteRenderer sprenderer;

    // Start is called before the first frame update
    void Start()
    {
        sprenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        float transitStep = transitTime / Time.fixedDeltaTime;
        if (status == 0)
        {
            if(timer >= hidingEnterTime)
            {
                status = 1;
                timer = 0;
            }
        }
        if(status == 1)
        {
            if(sprenderer.color.a > 0)
            {
                sprenderer.color = new Color(sprenderer.color.r, sprenderer.color.g, sprenderer.color.b, sprenderer.color.a - (1 / transitStep));
            }
            if (timer >= transitTime)
            {
                status = 2;
                timer = 0;
            }
        }
        if(status == 2)
        {
            if(timer >= hidingTime)
            {
                status = 3;
                timer = 0;
            }
        }
        if (status == 3)
        {
            if (sprenderer.color.a < 1)
            {
                sprenderer.color = new Color(sprenderer.color.r, sprenderer.color.g, sprenderer.color.b, sprenderer.color.a + (1 / transitStep));
            }
            if (timer >= transitTime)
            {
                status = 0;
                timer = 0;
            }
        }
    }
}
