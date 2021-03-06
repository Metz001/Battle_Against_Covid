using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyExplosion;

    [SerializeField]
    private GameObject laser2;
    


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


    [SerializeField]
    int id;



    // Update is called once per frame

    private void Start()
    {
        //uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>(); 
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(Shoot());
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
           
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 0.5f);
            vidas--;
            if(vidas <=0)
            {
                gameManager._UiManager.UpdateScore(scoreReward);
                if (id == 1)
                {
                    gameManager.destroyBoos = true;
                    gameManager.gameOver = true;
                    gameManager._UiManager.GameOver(true);
                }
                
            }
            
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
            
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 0.5f);
            vidas--;
            if (vidas <= 0)
            {
                gameManager._UiManager.UpdateScore(scoreReward/2);
                if (id == 1)
                {
                    gameManager.destroyBoos = true;
                    gameManager._UiManager.GameOver(true);
                }

            }
            //enemyDeath();
        }
    }
    public IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 6f));
            if (id == 1)
            {
                Instantiate(laser2, transform.position + new Vector3(0.95f, -1.6f, 0f), Quaternion.identity);
                Instantiate(laser2, transform.position + new Vector3(-0.95f, -1.6f, 0f), Quaternion.identity);
            }

            Instantiate(laser2, transform.position + new Vector3(0f, -1.6f, 0f), Quaternion.identity);

        }
          
        

    }
    void enemyDeath()
    {
       /* if (id == 1)
        {
            gameManager.destroyBoos = true;
            gameManager._UiManager.GameOver(true);
        }*/
           
        Instantiate(enemyExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
