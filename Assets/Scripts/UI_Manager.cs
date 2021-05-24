using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    Sprite[] spriteLives;
    public Image livesImage, titleScreen;
    public Text scoreText;
    public int actualScore;

    //lead borad
    private int[] leadScores = new int[5];
    public Text[] textScores = new Text[5];

    public void UpdateLives(int curretnLives)
    {
        livesImage.sprite = spriteLives[curretnLives];
    }
    public void UpdateScore(int score)
    {
        actualScore += score;
        scoreText.text = "Score: " + actualScore;
    }
    public void ShowTitleScreen()
    {
        BoardOrder(leadScores);
        for (int i = 0; i < leadScores.Length; i++)
            textScores[i].gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false);
        livesImage.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(true);
    }
    public void HideTitleScreen()
    {
        for (int i = 0; i < leadScores.Length; i++)        
            textScores[i].gameObject.SetActive(false);      
        titleScreen.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        livesImage.gameObject.SetActive(true);
    }

    //método para guardar y reordenar la tabla de posiciones

    private void LeadBoardIn() //
    {
        if (leadScores[4] < actualScore)
            leadScores[4] = actualScore;
    }
    private void BoardOrder(int[] leadScores)
    {
        LeadBoardIn();
        Array.Sort(leadScores);
        Array.Reverse(leadScores);
        //imprimir la tabal de posiciones 
        for (int i = 0; i < leadScores.Length; i++)
        {
            textScores[i].text = (i+1) + "...."+ leadScores[i];
        }
    }
}
