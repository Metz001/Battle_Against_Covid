using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public GameObject laserPrefab; //prefab del proyectil que dispara
    [SerializeField]
    private float fireRate = 0.25f; //rapidez de disparo
    private float nextFire = 0.0f; //
    public bool tripleShot = false;
    [HideInInspector]
    public float timePower;

    private AudioSource audioSource;
    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    public void Shoot()
    {
    
        if (Time.time > nextFire)
        {
            audioSource.Play();
            if (tripleShot == true)
            {

              Instantiate(laserPrefab, transform.position + new Vector3(-0.47f, -0.1f, 0f), Quaternion.identity);
              Instantiate(laserPrefab, transform.position + new Vector3(0.47f, -0.1f, 0f), Quaternion.identity);               
              StartCoroutine(PowerDown(timePower));

            }
            Instantiate(laserPrefab, transform.position + new Vector3(0f, 0.8f, 0f), Quaternion.identity);      
            nextFire = Time.time + (fireRate);
        }
    }

    
    public IEnumerator PowerDown(float t)
    {
        yield return new WaitForSeconds(t);
        tripleShot = false;
    }

    public void TripleShoot()
    {
        tripleShot = true;
        StartCoroutine(PowerDown(timePower));
    }
}
