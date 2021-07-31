using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform tf;
    public Animator anim;
    public Collider2D coll;
    public LayerMask ground;
    public float speed;
    public float jumpforce;
    public float cheeryFlyingTime;
    public float gemFlyingTime;
    /*游戏状态标识
     * 0 = 未开始
     * 1 = 进行中
     * 2 = 结束 */
    public int gameStatus = 0;

    void Start()
    {
        anim.SetBool("IsIdling", true);
    }

    void Update()
    {
        //Jump
        if (coll.IsTouchingLayers(ground))
        {
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }
    }
    void FixedUpdate()
    {
        Movement();
        FixedJump();
    }

    void Movement()
    {
        float horizontalmove = Input.GetAxis("Horizontal");
        float horizontalmoveRaw = Input.GetAxisRaw("Horizontal");
        if (horizontalmove != 0)
        {
            rb.velocity = new Vector2(horizontalmove * speed * Time.fixedDeltaTime, rb.velocity.y);
            anim.SetFloat("IsRunning", 1);
        }
        else
        {
            anim.SetFloat("IsRunning", 0);
        }
        if (horizontalmoveRaw != 0)
        {
            tf.localScale = new Vector3(horizontalmoveRaw, tf.localScale.y ,tf.localScale.z);
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        anim.SetBool("IsJumping", true);
        anim.SetBool("IsFalling", false);
        anim.SetBool("IsIdling", false);
    }
    void FixedJump()
    {
        if (anim.GetBool("IsJumping"))
        {
            if (rb.velocity.y < 0)
            {
                anim.SetBool("IsJumping", false);
                anim.SetBool("IsFalling", true);
            }
        }
        else if (anim.GetBool("IsFalling"))
        {
            if (coll.IsTouchingLayers(ground))
            {
                anim.SetBool("IsFalling", false);
                anim.SetBool("IsIdling", true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D triggercoll)
    {
        gameStatus = 1;
        triggercoll.GetComponent<Transform>();
        if (tf.position.y > triggercoll.transform.position.y)
        {
            if (triggercoll.tag == "PlatformDefault")
            {
                Jump();
            }
            if (triggercoll.tag == "PlatformUnstable")
            {
                Jump();
                Destroy(triggercoll.gameObject);
            }
            if ((triggercoll.tag == "PlatformFrog" || triggercoll.tag == "Eagle"))
            {
                Destroy(coll.gameObject);
                gameStatus = 2;
                Debug.Log("Game Over!");
            }
            if (triggercoll.tag == "PlatformCheery")
            {
                rb.velocity = new Vector2(rb.velocity.x, cheeryFlyingTime);
            }
            if (triggercoll.tag == "PlatformGem")
            {
                rb.velocity = new Vector2(rb.velocity.x, gemFlyingTime);
            }
        }
    }
}
