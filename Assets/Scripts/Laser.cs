using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float speed;
 
    // Update is called once per frame
    void Update()
    {    
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if(gameObject.transform.position.y >= 6f)
           Destroy(gameObject);        
    }

    /*
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player" && gameObject.tag != "Player")
        {
            Player player = other.GetComponent<Player>();
            if(player.vidas > 0)                                //Comportamiento para cuando el Enemy
            {                                                   //Pueda disparar sus propios láseres
                player.vidas--;                                             
                Debug.Log(player.vidas);
                Destroy(gameObject);
            }                   
            else if (player.vidas <= 0)
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
                
        }

    }*/


}
