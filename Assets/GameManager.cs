using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public bool gameOver = true;
    [HideInInspector]
    public bool destroyBoos = false;
    public GameObject player;

    [HideInInspector]
    public UI_Manager _UiManager;

    SpawnManager _SpawnManager;

    public int _score;
    private void Start()
    {
       
        gameOver = true;
        _SpawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _SpawnManager.boss = false;
       _UiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
    }

    private void Update()
    {
        
        if (gameOver == true)
        {

            _UiManager.ShowTitleScreen();
            if (Input.GetKeyDown(KeyCode.Space)) //Game start
            {
                Instantiate(player, Vector3.zero,Quaternion.identity);
                gameOver = false;
                _SpawnManager.boss = false;
                _SpawnManager.StartCoroutine(_SpawnManager.SpawnEnemy());
                _SpawnManager.StartCoroutine(_SpawnManager.SpawnPowerUp());
                _UiManager.HideTitleScreen();             
                _UiManager.actualScore = 0;
                _UiManager.scoreText.text = "Score: " + _UiManager.actualScore;
            }
        }
      
    }

    
}
