using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    public float speed = 2f;
    public Rigidbody2D rb;
    public LayerMask groundLayers;
    public Transform groundCheck;
    bool isFacingRight;
    RaycastHit2D hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        hit = Physics2D.Raycast(groundCheck.position, -transform.up, 1f, groundLayers);
    }

    
}
