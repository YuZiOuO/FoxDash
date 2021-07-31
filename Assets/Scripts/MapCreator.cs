using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    public Transform playertf;
    public GameObject PlatformDefault;
    public GameObject PlatformUnstable;
    public GameObject PlatformFrog;
    public GameObject PlatformCheery;
    public GameObject PlatformGem;
    public GameObject Eagle;
    // Start is called before the first frame update
    void Start()
    {
        for (float y = 1; y <= 200; y += 2)
        {
            GameObject platform = Instantiate(PlatformDefault);
            platform.transform.position = new Vector3(Random.Range((float)-6.6,(float)6.6), y, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}