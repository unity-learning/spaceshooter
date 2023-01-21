using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public float speed;
    public GameObject asteroid;
    public float rotationSpeed;
    public float health;
    public GameObject explosionPrefab;



    void Start()
    {
        
    }


    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;

        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health = health - collision.gameObject.GetComponent<BulletController>().power;
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (health <= 0) {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        
        }
    }

}
