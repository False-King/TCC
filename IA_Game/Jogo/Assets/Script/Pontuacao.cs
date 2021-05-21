using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class Pontuacao : MonoBehaviour
{
    // Start is called before the first frame update
    Text pontuacao,hp;
    void Start()
    {
        pontuacao = GameObject.Find("Canvas/Text").GetComponent<Text>();
        hp = GameObject.Find("Canvas/Vida").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        pontuacao.text ="Pontuação: " + Player.score;
        hp.text ="HP: " + Player.hp;
    }
}
