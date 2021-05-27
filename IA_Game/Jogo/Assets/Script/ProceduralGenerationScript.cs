using System.Linq;
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
            arvore();
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


    // Cria Plataformas baseado nas probabilidades definidas
    void criarPlataform()
    {
        GameObject Plataforma;
        int j=1;
        float z=0;


        while(z<comprimento)
        {   
            setNewHeight();
            int valorInimigo = Random.Range(1, 100);
            if(Random.Range(1, 100)<=pequeno)
            {
                
                z+=(float)(1.25);
                if(distancia>6&&heightDif>=3)
                    z+=-1;
                Plataforma = Instantiate(blocoP, new Vector2(z+32, height), Quaternion.identity);
                Plataforma.transform.parent = contaninerPlataforma.transform;
                Plataforma.name = "Plataforma " + (j);
                j++;

                if(valorInimigo<=difInimigo)
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
            else if(Random.Range(1, 100)<=grande)
            {
                z+=(float)(5);
                if(distancia>6&&heightDif>=3)
                    z+=-1;
                Plataforma = Instantiate(blocoG, new Vector2(z+32, height), Quaternion.identity);
                Plataforma.transform.parent = contaninerPlataforma.transform;
                Plataforma.name = "Plataforma " + (j);
                j++;

                if(valorInimigo<=difInimigo)
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

                if(valorInimigo<=difInimigo)
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
        print(grande);

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
    }
    public void arvore()
    {   
        if(Player.final=="enemy"){
            if(porcentagemDistancia < 0.50){
                if(Enemy.speed==2){
                    if(difInimigo>=0){
                        difInimigo-=10;
                    }
                }else{
                    Enemy.speed = Enemy.speed - (Enemy.speed * (float)(0.15));
                }
            }else{
                if(porcentagemDistancia > 0.50){
                    if(difInimigo>=0){
                        difInimigo-=10;
                    }else{
                        if(Enemy.speed>2){
                            Enemy.speed = Enemy.speed - (Enemy.speed * (float)(0.15));
                        }
                    }
                }
            }
        }
        if(Player.final=="fall"){
            if(porcentagemDistancia >0.79){
                if(distancia>3){
                    distancia = distancia - (distancia * (float)(0.1));
                }else{

                    if(pequeno>0){
                        pequeno-=10;
                    }else{
                        if(grande<100){
                            grande+=10;
                        }
                    }
                }
            }else{
                if(Player.hasDoubleJump){
                    if(distancia>3){
                        distancia = distancia - (distancia * (float)(0.1));
                    }
                }else{
                    if(Player.consecutiveFallDeath==3){
                        Player.hasDoubleJump = true;
                    }else{
                        if(distancia>3){
                            distancia = distancia - (distancia * (float)(0.1));
                        }else{
                            if(pequeno>0){
                                pequeno-=10;
                            }else{
                                if(grande<100){
                                    grande+=10;
                                }
                            }
                        }
                    }
                }
            }
        }
        if(Player.final=="win"){
            if(Player.hasDoubleJump && Player.consecutiveVictory==3){
                Player.hasDoubleJump = false;
            }else{
                if(Player.hp==3){
                    if(pequeno<50){
                        pequeno+=10;
                    }else{
                        if(grande>0){
                            grande-=10;
                        }
                    }
                    if(distancia<7){
                        distancia = distancia + (distancia * (float)(0.25));
                    }
                    if(Enemy.speed<5){
                        Enemy.speed = Enemy.speed + (Enemy.speed * (float)(0.25));
                    }
                    if(difInimigo<50){
                        difInimigo+=10;
                    }
                }
                if(Player.hp==2){
                    int i = Random.Range(1, 9);
                    if(i>4){
                        if(pequeno<50){
                        pequeno+=10;
                        }else{
                            if(grande>0){
                                grande-=10;
                            }
                        }
                    }else if(i<6){
                            if(Enemy.speed<5){
                            Enemy.speed = Enemy.speed + (Enemy.speed * (float)(0.25));
                            }                    
                        }
                    else{
                        if(difInimigo<50){
                            difInimigo+=10;
                        }
                    }

                }
                if(Player.hp==1){
                    if(distancia<7){
                        distancia = distancia + (distancia * (float)(0.25));
                    }
                }
            }
        }
    comprimento+=20;
    limites();
    
    }
        
        public void limites(){
            if(grande<0){
                grande = 0;
            }
            if(grande>100){
                grande = 100;
            }
            if(pequeno>50){
                pequeno = 50;
            }
            if(pequeno<0){
                pequeno = 0;
            }
            if(distancia>7){
                distancia=7;
            }
            if(distancia<2){
                distancia=2;
            }
            if(difInimigo>50){
                difInimigo=50;
            }
        }
    }





