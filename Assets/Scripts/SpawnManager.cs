﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] powerups;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
       // gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnPowerUp());
        if (gameManager != null)
            Debug.Log("objeto encontrado");
    }
    


    //corrutina spawn enemigos cada x tiempo, 5seg
    IEnumerator SpawnEnemy()
    {
        while (gameManager.gameOver == false) 
        {
            yield return new WaitForSeconds(2);
            Instantiate(enemyPrefab, new Vector3(Random.Range(-8f, 8f), 6f, 0), Quaternion.identity);
        }
       
    }

    //corrutina de spawn de power ups
    IEnumerator SpawnPowerUp()
    {
        while (gameManager.gameOver == false)
        {
            int r = Random.Range(0,powerups.Length);
            yield return new WaitForSeconds(5f);
            Instantiate(powerups[r], new Vector3(Random.Range(-8f, 8f), 6f, 0), Quaternion.identity);
        }

    }
}
