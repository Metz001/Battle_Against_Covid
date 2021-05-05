﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    Sprite[] spriteLives;
    public Image livesImage;
    public Text scoreText;
    public int _score;

    public void UpdateLives(int curretnLives)
    {
        livesImage.sprite = spriteLives[curretnLives];
    }
    public void UpdateScore(int score)
    {
        _score += score;

        scoreText.text = "Score: " + _score;
    }
}