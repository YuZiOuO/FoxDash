using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    public Transform tf;
    public GameObject player;
    public float platformDistanceLimit;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y - tf.position.y >= platformDistanceLimit)
        {
            Destroy(tf.gameObject);
        }
    }
}
