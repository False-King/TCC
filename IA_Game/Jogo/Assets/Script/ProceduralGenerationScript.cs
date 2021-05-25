using System.ComponentModel;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Threading.Tasks;

public class ProceduralGenerationScript : MonoBehaviour
{
    // Variaveis que serão acessadas por outros arquivos são chamadas de Static
    public static float pequeno=0,grande=60,difInimigo=0,comprimento=50,distancia=3;
    public static bool  destroy;

    // Variaveis com SerializeField são editaveis pelo Hub do Unity
    [SerializeField] public int height,heightDif,pont;
    [SerializeField] public GameObject bloco, final, inimigo, blocoP, blocoG, contaninerPlataforma;

    //Variaveis Normais
    public int posicaoPlayer;
    public float porcentagemDistancia;    
    public int pontos =  Player.score;
   

    // Start é apenas executado no começo do jogo
    void Start()
    {
        criarPlataform();
        
    }
    
    // Update é executado a cada frame
    void Update()
    {
        if(destroy){
            DestroyPlataform();
            
            criarPlataform();
            distanciaPercorrida();
        }
        
    }

    // define uma nova altura para a plataforma
    void setNewHeight()
    {
        heightDif=height;
        if(height<=2)
            height=height+Random.Range(0, 4);
        else if(height>=4)
            height=height+Random.Range(-4, 0);
        else
            height=height+Random.Range(-4, 2);
        heightDif=height-heightDif;
    }

    // Define a probabilidade da criaçao de plataformas e inimigos
    // Tem que ser removido e alterado baseado com o desempenho do usuario
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

    // Cria Plataformas baseado nas probabilidades definidas
    void criarPlataform()
    {
        GameObject Plataforma;
        int j=1;
        float z=0;


        while(z<comprimento)
        {   
            setNewHeight();
            if(Random.Range(0, 100)<=pequeno)
            {
                
                z+=(float)(1.25);
                if(distancia>6&&heightDif>=3)
                    z+=-1;
                Plataforma = Instantiate(blocoP, new Vector2(z+32, height), Quaternion.identity);
                Plataforma.transform.parent = contaninerPlataforma.transform;
                Plataforma.name = "Plataforma " + (j);
                j++;

                if(Random.Range(0, 100)<=difInimigo)
                {
                    Plataforma = Instantiate(inimigo, new Vector2(z+12, height), Quaternion.identity);
                    Plataforma.transform.parent = contaninerPlataforma.transform;
                    z+=(float)(distancia-1+1.25);
                }
                else
                {
                    z+=(float)(distancia+1.25);
                }

            }
            else if(Random.Range(0, 100)<=grande)
            {
                z+=(float)(5);
                if(distancia>6&&heightDif>=3)
                    z+=-1;
                Plataforma = Instantiate(blocoG, new Vector2(z+32, height), Quaternion.identity);
                Plataforma.transform.parent = contaninerPlataforma.transform;
                Plataforma.name = "Plataforma " + (j);
                j++;

                if(Random.Range(0, 100)<=difInimigo)
                {
                    Plataforma = Instantiate(inimigo, new Vector2(z+12, height), Quaternion.identity);
                    Plataforma.transform.parent = contaninerPlataforma.transform;
                }
                z+=(float)(distancia+5);
            }
            else{
                z+=(float)(2.5);
                if(distancia>6&&heightDif>=3)
                    z+=-1;
                Plataforma = Instantiate(bloco, new Vector2(z+32, height), Quaternion.identity);
                Plataforma.transform.parent = contaninerPlataforma.transform;
                Plataforma.name = "Plataforma " + (j);
                j++;

                if(Random.Range(0, 100)<=difInimigo)
                {
                    Plataforma = Instantiate(inimigo, new Vector2(z+12, height), Quaternion.identity);
                    Plataforma.transform.parent = contaninerPlataforma.transform;
                }
                z+=(float)(distancia+2.5);
                
            }
        }
        
        setNewHeight();
        Plataforma = Instantiate(final, new Vector2(z+32, height), Quaternion.identity);
        Plataforma.transform.parent = contaninerPlataforma.transform;
        Plataforma.name = "Final Oficial";

    }


    // Destroi todas as plataformas criadas pela função de criação
    public void DestroyPlataform()
    {
        var plataformas = new List<GameObject>();
        foreach (Transform child in contaninerPlataforma.transform) plataformas.Add(child.gameObject);
        plataformas.ForEach(child => Destroy(child));
        destroy = false;
    }

    // calcula un float que pega a porcentagem que o usuario conseguiu alcançar na fase (0.x%, sendo 1.00 = 100%)
    public void distanciaPercorrida()
    {
        float distanciaTotal = comprimento+12;
        porcentagemDistancia = Player.deathPosition/distanciaTotal;
        print(porcentagemDistancia.ToString());
    }
}




