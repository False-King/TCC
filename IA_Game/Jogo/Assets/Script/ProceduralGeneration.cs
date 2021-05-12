using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int pontos, height;
    [SerializeField] GameObject bloco;
    void Start()
    {
        generation();

    }
    void generation()
    {
        setNewHeight();
        for (int x = 5; x<pontos; x+=8)
        {
            Instantiate(bloco, new Vector2(x, height), Quaternion.identity);
            setNewHeight();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setNewHeight()
    {
        height=height+Random.Range(-5, 5);
    }
}
