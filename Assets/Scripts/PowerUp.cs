using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float speedFall;
    [SerializeField]
    private int powerUpId; // 0 = tripleshot / 1 = speed boost / 2 = shiled
    [SerializeField]
    private float powerDownTime; //Timepo que dura el poder
    [SerializeField]
    private float speedPlus; //aumento de velocidad
    [SerializeField]
    private AudioClip _clip;

    

    private void Update()
    {
        transform.Translate(Vector3.down *speedFall * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            Canon canonPlayer = player.GetComponent<Canon>();

            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 0.7f);
            if (canonPlayer != null)
            {
                if(powerUpId == 0)
                {
                    canonPlayer.timePower = powerDownTime;
                    canonPlayer.TripleShoot();
                    Destroy(gameObject);
                }
                else if(powerUpId == 1)
                {                  
         
                    player.timePower = powerDownTime;
                    player._speedPlus = speedPlus;
                    player.isSpeedBoostActive = true;
                    Destroy(gameObject);
                }
                else if(powerUpId == 2)
                {
                    player.shield = 1;
                    player.shieldGameObject.SetActive(true);
                    Destroy(gameObject);
                }
                else if (powerUpId == 3)
                {
                    
                   
                    if (player.vidas <3)
                    {
                        player.vidas++;
                        player.uiManager.UpdateLives(player.vidas);
                    }
                                        
                    Destroy(gameObject);
                }

            }
            else
            {
                throw new NullReferenceException(message:"No Canon in the Player");
            }                                   
        }
        
    }
   

}
