using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipController : MonoBehaviour
{
    public float vSpeed;
    public float hSpeed;
    public GameObject bulletPrefab;
    public Vector2 timeToFire;
    public GameObject gun;

    private int direction = 0 ;


    private void Start()
    {
        InvokeRepeating("ChangeDirection", 1, 0.5f);        
        InvokeRepeating("Fire", timeToFire.x, timeToFire.y);
    }


    private void Update()
    {
        Vector3 move = Vector3.down;
        move.x = direction * hSpeed;
        move.y = move.y * vSpeed;
        transform.position += move * Time.deltaTime;
        CheckSpaceShipOutOfBounds();
    }


    private void ChangeDirection()
    {
        direction =  Random.Range(-1, 2);
    }

    private void CheckSpaceShipOutOfBounds()
    {
        transform.position = new Vector3(
                    Mathf.Clamp(transform.position.x, -6.7f, 6.7f),
                    transform.position.y,
                    transform.position.z
                    );
    }

    private void Fire()
    {
        Instantiate(bulletPrefab, gun.transform.position, Quaternion.identity);
    }
}
