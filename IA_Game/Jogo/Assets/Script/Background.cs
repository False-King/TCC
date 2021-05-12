using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Transform CameraPosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         transform.position = new Vector3(CameraPosition.position.x, CameraPosition.position.y, 0);
    }
}
