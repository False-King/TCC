using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider2d;
    public float speed;
    public float jumpforce;
    private Rigidbody2D rig;

    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        jump();
    }

    void move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime *speed;
    }

    void jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            rig.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);
        }
    }


    
}
