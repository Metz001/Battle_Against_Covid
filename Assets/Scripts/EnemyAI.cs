using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyExplosion;

    [SerializeField]
    private float speed;

    [SerializeField]
    private AudioClip _clip;

    //private UI_Manager uiManager;
    private GameManager gameManager;

    [SerializeField]
    int scoreReward;

    [SerializeField]
    int vidas;
    // Update is called once per frame

    private void Start()
    {
        //uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>(); 
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
       
    }
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
              
      if (transform.position.y <= -6.2f)
        {
            transform.position = new Vector3(Random.Range(-6.7f, 7.7f), 6.2f, 0f); 
        }

        if (gameManager.gameOver == true || vidas <= 0)
        {
            enemyDeath();
        }
    }
 


    //Choque de Eemigo y player
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Laser")
        {
            Destroy(other.gameObject);
            //uiManager.UpdateScore(scoreReward);
            gameManager._UiManager.UpdateScore(scoreReward);
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 0.5f);
            vidas--;
            //enemyDeath();
        }
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if(player != null)                  //Esto es el método de daño
            {
                player.Damage();            //player recibe daño
            }
            //uiManager.UpdateScore(scoreReward/2);
            gameManager._UiManager.UpdateScore(scoreReward/2);
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 0.5f);
            vidas--;
            //enemyDeath();
        }
    }

    void enemyDeath()
    {

        Instantiate(enemyExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
