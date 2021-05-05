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
                    player.shield = 3;
                    player.shieldGameObject.SetActive(true);
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
