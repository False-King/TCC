using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider2d;

    
    public float speed;
    public float jumpforce;
    public bool isJumping;

    private Rigidbody2D rig;
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        isJumping = false;
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        jump();
        detectDeath();
    }

    void move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime *speed;

        if(Input.GetAxis("Horizontal") > 0f)
        {
            anim.SetBool("Run", true);
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }
        if(Input.GetAxis("Horizontal") < 0f)
        {
            anim.SetBool("Run", true);
            transform.eulerAngles = new Vector3(0f,180f,0f);
        }
        if(Input.GetAxis("Horizontal") == 0f)
        {
            anim.SetBool("Run", false);
        }
    }

    void jump()
    {
        if(Input.GetButtonDown("Jump") && isJumping==false)
        {
            rig.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);
        }
        if(isJumping==true)
        {
            if(Input.GetAxis("Vertical") >= 0f)
            {
                anim.SetBool("Jump", true);
                anim.SetBool("Fall", false);
            }
            if(rig.velocity.y < -0.1)
            {
                anim.SetBool("Jump", false);
                anim.SetBool("Fall", true);
            }
        }
        if(isJumping == false)
        {
            anim.SetBool("Jump", false);
            anim.SetBool("Fall", false);
        }
    }

    void detectDeath()
    {
        if(transform.position.y<=-20)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = false;
        }
        if(collision.gameObject.tag == "Finish")
        {
            Application.LoadLevel(Application.loadedLevel);
            print("aaaaaaaaaaaaaa");
        }
        if(collision.gameObject.tag == "Enemy")
        {
            isJumping = false;
            Application.LoadLevel(Application.loadedLevel);
        }

    }

    void OnCollisionExit2D (Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }

    
}
