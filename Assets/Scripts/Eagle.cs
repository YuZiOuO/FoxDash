using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform tf;
    public float speed;
    public int direction = 0;
    public bool allowChangeDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();
        direction = Random.Range(-1, 2);
        allowChangeDirection = true;
        if (direction != 0)
        {
            tf.localScale = new Vector3(-direction*tf.localScale.x,tf.localScale.y,tf.localScale.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(direction != 0)
        {
            rb.velocity = new Vector2(direction * speed,rb.velocity.y);
        }
        if((transform.position.x <= -6.6 || transform.position.x >= 6.6) && allowChangeDirection)
        {
            direction = -direction;
            tf.localScale = new Vector3(-tf.localScale.x, tf.localScale.y, tf.localScale.z);
            rb.velocity = new Vector2(direction * speed, rb.velocity.y);
            allowChangeDirection = false;
        }
        if (tf.position.x >= -1 && tf.position.x <= 1)
        {
            allowChangeDirection = true;
        }
    }
}
