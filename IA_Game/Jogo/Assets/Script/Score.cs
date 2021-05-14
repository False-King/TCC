using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class Score : MonoBehaviour
{
    public Text scoreText;
    static string scoreTxt = System.IO.File.ReadAllText("../Jogo/Assets/Save/Score.txt");   
    public int score = Convert.ToInt32(scoreTxt);
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text="Pontuação: "+ score;
    }
    // Update is called once per frame
}
