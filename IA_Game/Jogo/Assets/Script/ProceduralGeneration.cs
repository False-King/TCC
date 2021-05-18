using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ProceduralGeneration : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int height,pont;
    int x=32,pequeno,grande,difInimigo;
    int pontos =  System.Convert.ToInt32(System.IO.File.ReadAllText("../Jogo/Assets/Save/Score.txt"));
    [SerializeField] GameObject bloco, final, inimigo, blocoP, blocoG;
    void Start()
    {
        generation();
    }
    void generation()
    {
        checkDificuldade();
        //for (x = 37; x<pontos; x+=8)
        while(pont<pontos)
        {   
            setNewHeight();
            setPlat();

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
        if(Random.Range(0, 10)>=pequeno){

            Instantiate(blocoP, new Vector2(x, height), Quaternion.identity);

            if(Random.Range(0, 10)>=difInimigo)
            {
                Instantiate(inimigo, new Vector2(x-20, height), Quaternion.identity);
            }

            x+=6;
            pont+=15;
        }
        else if(Random.Range(0, 10)<=grande){
            
            Instantiate(blocoG, new Vector2(x, height), Quaternion.identity);

            if(Random.Range(0, 10)>=difInimigo)
            {
                Instantiate(inimigo, new Vector2(x-20, height), Quaternion.identity);
            }

            x+=10;
            pont+=5;
        }
        else{

            Instantiate(bloco, new Vector2(x, height), Quaternion.identity);

            if(Random.Range(0, 10)>=difInimigo)
            {
                Instantiate(inimigo, new Vector2(x-20, height), Quaternion.identity);
            }

            x+=8;
            pont+=10;
        }
    }

    void checkDificuldade()
    {   
        if(pontos<=30){
            difInimigo = 10;
            grande = 6;
            pequeno = 10;
        }else if(pontos>100){
            difInimigo = 5;
            grande = 1;
            pequeno = 6;
        }else
        {
            difInimigo = 8;
            grande = 3;
            pequeno = 9;
        }
    }
}
