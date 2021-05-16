using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class Pontuacao : MonoBehaviour
{
    // Start is called before the first frame update
     Text pontuacao;
    void Start()
    {
        string scoreTxt = System.IO.File.ReadAllText("../Jogo/Assets/Save/Score.txt");  
        int score = Convert.ToInt32(scoreTxt);
  
        pontuacao = GameObject.Find("Canvas/Text").GetComponent<Text>();

        pontuacao.text = "text";


    }

    // Update is called once per frame
    void Update()
    {
        string scoreTxt = System.IO.File.ReadAllText("../Jogo/Assets/Save/Score.txt");  
        int score = Convert.ToInt32(scoreTxt);
        
        pontuacao.text = "Pontuação: " + score;
    }
}
