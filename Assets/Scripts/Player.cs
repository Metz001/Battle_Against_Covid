using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   
    [SerializeField]
    public float speed; //vel
    private float initialSpeed; //velocidad inical
    public bool isSpeedBoostActive; //bool de activación de poder Speedboost
    [HideInInspector]
    public float _speedPlus; //¿que tanto aumenta la velocidad?

    [SerializeField]
    private float limX, limSup, limInf; // Límites de movimiento

    [SerializeField]
    private Canon canon;//Poder de disparo de cañon triple
    [SerializeField]
    GameObject explosion;

    [HideInInspector]
    public float timePower;//tiempo que dura un efecto de poder

    public int vidas; //número de vidas
    public int shield; //resistencai escudo
    [SerializeField]
   public GameObject shieldGameObject;

    private UI_Manager uiManager;
    private GameManager gameManager;

    void Start()
    {
        Debug.Log("_velocidad es "+speed);
        initialSpeed = speed; //velocidad inicial = velocidad 
        canon = GetComponent<Canon>(); //obtener cañón, arma con la que dispara
        transform.position = Vector3.zero; //esto hace que su posición inicil sea simepre cero

        vidas = 3; //asignación de numeros de vida
        shieldGameObject = transform.Find("Shields").gameObject;
        shieldGameObject.SetActive(false);
        uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
        if(uiManager != null)
        {
            uiManager.UpdateLives(vidas);
        }

        gameManager = GameObject.FindObjectOfType<GameManager>();
        //gameManager = GameObject.Find("Canvas").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement(); //llamamos el método movimiento
        //Disparo
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
            canon.Shoot();         
    }

   
    //método movimeinto
    private void Movement()
    {

       // Debug.Log("_velocidad es " + speed);
        if (isSpeedBoostActive)
            speedPower(_speedPlus);         

        //Traslación por teclas de movimiento
        //traslación conrrespecto al tiempo permitiedno mov horizontal y vertical
        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * speed
           , Input.GetAxis("Vertical") * Time.deltaTime * speed, 0f));
        //transform.Translate(new Vector2(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0f));
        #region limites de movimiento
        if (transform.position.x > limX)
            transform.position = new Vector3(limX, transform.position.y, 0f);
        else if (transform.position.x < -limX)
            transform.position = new Vector3(-limX, transform.position.y, 0f);

        if (transform.position.y > limSup)
            transform.position = new Vector3(transform.position.x, limSup, 0f);
        else if (transform.position.y < limInf)
            transform.position = new Vector3(transform.position.x, limInf, 0f);
        #endregion
    }

    public void Damage()
    {          
        if(vidas>0 && shield > 0)
        {
            shield--;
            if (shield <= 0)
               shieldGameObject.SetActive(false);          
            Debug.Log("quedan " + shield + " de escudo");
        }
        else if (vidas > 0)
        {
            vidas--;
            uiManager.UpdateLives(vidas);
            if(vidas <= 0)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                gameManager.gameOver = true;
                Destroy(gameObject);               
            }
        }

        Debug.Log("quedan " + vidas + " vidas");
    }
    public void speedPower(float speedPlus)
    {
        //speedPlus = _speedPlus;
        speed = speedPlus;
        StartCoroutine(PowerDown(timePower));
    }
    public IEnumerator PowerDown(float t)
    {
        yield return new WaitForSeconds(t);
        isSpeedBoostActive = false;
        speed = initialSpeed;
    }
}
