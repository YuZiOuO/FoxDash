using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFix: MonoBehaviour
{
    public Transform tf;
    public Transform playertf;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        tf.position = new Vector3(playertf.position.x, playertf.position.y, tf.position.z);
    }
}
