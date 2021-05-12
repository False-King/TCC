using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int pontos, height;
    [SerializeField] GameObject bloco, final;
    void Start()
    {
        generation();

    }
    void generation()
    {
        for (int x = 5; x<pontos-16; x+=8)
        {   
            setNewHeight();
            Instantiate(bloco, new Vector2(x, height), Quaternion.identity);

        }
        Instantiate(final, new Vector2(pontos, height), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setNewHeight()
    {
        height=height+Random.Range(-4, 4);
    }
}
