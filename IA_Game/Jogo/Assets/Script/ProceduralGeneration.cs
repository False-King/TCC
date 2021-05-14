using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ProceduralGeneration : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int height, x=37;
    int pontos =  System.Convert.ToInt32(System.IO.File.ReadAllText("../Jogo/Assets/Save/Score.txt"));
    [SerializeField] GameObject bloco, final, inimigo, blocoP, blocoG;
    void Start()
    {
        generation();
    }
    void generation()
    {
        //for (x = 37; x<pontos; x+=8)
        while(x<pontos)
        {   
            setNewHeight();
            setPlat();
            if(Random.Range(0, 10)>=7)
            {
                Instantiate(inimigo, new Vector2(x-32, height), Quaternion.identity);
            }
        }
        setNewHeight();
        Instantiate(final, new Vector2(x, height), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //set uma nova altura da plataforma
    void setNewHeight()
    {
        if(height<=2)
            height=height+Random.Range(0, 4);
        else if(height>=4)
            height=height+Random.Range(-4, 0);
        else
            height=height+Random.Range(-4, 4);
    }

    //criação de uma plataforma aleatória
    void setPlat()
    {
        if(Random.Range(0, 10)>=8){
            Instantiate(blocoP, new Vector2(x, height), Quaternion.identity);
            x+=4;
        }
        else if(Random.Range(0, 10)<=2){
            Instantiate(blocoG, new Vector2(x, height), Quaternion.identity);
            x+=14;
        }
        else{
            Instantiate(bloco, new Vector2(x, height), Quaternion.identity);
            x+=8;
        }
    }

    void setTrap()
    {

    }
}
