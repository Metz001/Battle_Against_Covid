using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private int dir = 1;

    [SerializeField]
    private AudioClip _clip;


    // Update is called once per frame
    void Update()
    {    
        transform.Translate((Vector3.up*dir) * speed * Time.deltaTime);
        if(gameObject.transform.position.y >= 6f)
           Destroy(gameObject);        
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player" && dir ==-1)
        {
            Player player = other.GetComponent<Player>();
            player.Damage();
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 0.5f);

        }

    }


}
