using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform Player;
    public Transform CameraPosition;

    float cameraY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        setCameraY();
        transform.position = new Vector3(Player.position.x +5, cameraY, -10);
        
    }

    void setCameraY()
    {
        if(Player.position.y > 4.5)
        {
            cameraY = Player.position.y - (float)(4.5); 
        }
    }


}
