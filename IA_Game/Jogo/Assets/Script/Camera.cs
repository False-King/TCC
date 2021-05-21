using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform Player;
    public Transform CameraPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.position.x-2 > CameraPosition.position.x)
        {
            transform.position = new Vector3(Player.position.x-2, 0, -10);
        }
        if(Player.position.x+4 < CameraPosition.position.x)
        {
            transform.position = new Vector3(Player.position.x +5, 0, -10);
        }
    }


}
