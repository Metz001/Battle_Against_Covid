using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] powerups;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private GameManager gameManager;
    public float spawnTime_PowerUp, spawnTime_Enemy;
    [HideInInspector]
   public bool boss;

    // Start is called before the first frame update
    /*
    void Start()
    {
       // gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //StartCoroutine(SpawnEnemy());
        //StartCoroutine(SpawnPowerUp());
       
    }*/
    


    //corrutina spawn enemigos cada x tiempo, 5seg
    public IEnumerator SpawnEnemy()
    {
        while (gameManager.gameOver == false) 
        {
            yield return new WaitForSeconds(spawnTime_Enemy);
            Instantiate(enemyPrefab, new Vector3(Random.Range(-8f, 8f), 6f, 0), Quaternion.identity);
            if (gameManager._UiManager.actualScore > 1500 && boss == false)
            {
                Instantiate(bossPrefab, new Vector3(0, 6f, 0), Quaternion.identity);
                boss = true;
            }

        }
       
    }

    //corrutina de spawn de power ups
    public IEnumerator SpawnPowerUp()
    {
        while (gameManager.gameOver == false)
        {
           
            int r = Random.Range(0,powerups.Length);
            yield return new WaitForSeconds(spawnTime_PowerUp);
            Instantiate(powerups[r], new Vector3(Random.Range(-8f, 8f), 6f, 0), Quaternion.identity);
        }

    }

   
}
