using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public bool gameOver = true;
    public GameObject player;

    private UI_Manager _UiManager;

    private void Start()
    {
        _UiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
    }

    private void Update()
    {
        if (gameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(player, Vector3.zero,Quaternion.identity);
                gameOver = false;
                _UiManager.HideTitleScreen();
            }
        }
    }
}
