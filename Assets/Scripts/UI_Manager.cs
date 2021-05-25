using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    Sprite[] spriteLives;
    public Image livesImage, titleScreen;
    public Text scoreText;
    public int actualScore;

    //lead borad
    private int leadScores;
    public Text textScores;

 
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
        BoardOrder();
        /* for (int i = 0; i < leadScores.Length; i++)
             textScores[i].gameObject.SetActive(true);*/
        textScores.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false);
        livesImage.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(true);
    }
    public void HideTitleScreen()
    {
        /*for (int i = 0; i < leadScores.Length; i++)        
            textScores[i].gameObject.SetActive(false);   */
        textScores.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        livesImage.gameObject.SetActive(true);
    }

    //método para guardar y reordenar la tabla de posiciones

    
    private void BoardOrder()
    {
        /*  if (actualScore > leadScores[0])
               leadScores[0] = actualScore;*/
        if (leadScores < actualScore)
            leadScores = actualScore;
        //Array.Sort(leadScores);

        //Array.Reverse(leadScores);
        /*
        //ordena el arreglo
       
        //invertir arreglo
        leadScores[0] = leadScores[4];
        leadScores[1] = leadScores[3];
        leadScores[2] = leadScores[2];
        leadScores[3] = leadScores[1];
        leadScores[4] = leadScores[0];
        */

        //imprimir la tabal de posiciones 
        textScores.text = "Best Score...." + leadScores;
        /*
         textScores[1].text = "2...." + leadScores[3];
         textScores[2].text = "3...." + leadScores[2];
         textScores[3].text = "4...." + leadScores[1];
         textScores[4].text = "5...." + leadScores[0];*/
        /*
        for (int i = 0; i < leadScores.Length; i++)
        {
            textScores[i].text = (i+1) + "...."+ leadScores[i];
        }*/
    }
}
