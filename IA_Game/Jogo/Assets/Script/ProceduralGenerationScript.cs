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
    // Start is called before the first frame update
    int comprimento=180;
    [SerializeField] public int height,pont;
    public int x=32,tamanho,distancia=10,posicaoPlayer;
    public float pequeno,grande,difInimigo,porcentagemDistancia;
    public static bool  destroy;
    public int pontos =  Player.score;
    [SerializeField] public GameObject bloco, final, inimigo, blocoP, blocoG, contaninerPlataforma;

    
    void Start()
    {
        criarPlataform();
        
    }
    void Update()
    {
        if(destroy){
            DestroyPlataform();
            
            criarPlataform();
            distanciaPercorrida();
        }
        
    }

    //set uma nova altura da plataforma
    void setNewHeight()
    {
        if(height<=2)
            height=height+Random.Range(0, 4);
        else if(height>=4)
            height=height+Random.Range(-4, 0);
        else
            height=height+Random.Range(-4, 2);
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

    void criarPlataform()
    {
        GameObject Plataforma;
        int z=0, j=1;

        checkDificuldade();

        while(z<comprimento)
        {   
            setNewHeight();
            if(Random.Range(0, 10)>=pequeno)
            {

                Plataforma = Instantiate(blocoP, new Vector2(z+32, height), Quaternion.identity);
                Plataforma.transform.parent = contaninerPlataforma.transform;
                Plataforma.name = "Plataforma " + (j);
                j++;

                if(Random.Range(0, 10)>=difInimigo)
                {
                    Plataforma = Instantiate(inimigo, new Vector2(z+12, height), Quaternion.identity);
                    Plataforma.transform.parent = contaninerPlataforma.transform;
                    z+=distancia-1;
                }
                else
                {
                    z+=distancia;
                }

            }
            else if(Random.Range(0, 10)<=grande)
            {
            
                Plataforma = Instantiate(blocoG, new Vector2(z+32, height), Quaternion.identity);
                Plataforma.transform.parent = contaninerPlataforma.transform;
                Plataforma.name = "Plataforma " + (j);
                j++;

                if(Random.Range(0, 10)>=difInimigo)
                {
                    Plataforma = Instantiate(inimigo, new Vector2(z+12, height), Quaternion.identity);
                    Plataforma.transform.parent = contaninerPlataforma.transform;
                }
                z+=distancia+3;
            }
            else{

                Plataforma = Instantiate(bloco, new Vector2(z+32, height), Quaternion.identity);
                Plataforma.transform.parent = contaninerPlataforma.transform;
                Plataforma.name = "Plataforma " + (j);
                j++;

                if(Random.Range(0, 10)>=difInimigo)
                {
                    Plataforma = Instantiate(inimigo, new Vector2(z+12, height), Quaternion.identity);
                    Plataforma.transform.parent = contaninerPlataforma.transform;
                }
                z+=distancia;
                
            }
        }
        
        setNewHeight();
        Plataforma = Instantiate(final, new Vector2(z+32, height), Quaternion.identity);
        Plataforma.transform.parent = contaninerPlataforma.transform;
        Plataforma.name = "Final Oficial";

    }
    public void DestroyPlataform()
    {
        var plataformas = new List<GameObject>();
        foreach (Transform child in contaninerPlataforma.transform) plataformas.Add(child.gameObject);
        plataformas.ForEach(child => Destroy(child));
        destroy = false;
    }

    public void distanciaPercorrida()
    {
        int distanciaTotal = comprimento+12;
        porcentagemDistancia = Player.deathPosition/distanciaTotal;
        print(porcentagemDistancia.ToString());
    }
}




