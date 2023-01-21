using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    #region Public Variables
    #endregion

    [Header("SpaceShip Settings")]
    public float speed;
    public GameObject bullet;
    public GameObject gun;

    private void Start()
    {
        
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.position += new Vector3(h, v, 0) * speed * Time.deltaTime;
        CheckSpaceShipOutOfBounds();
        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(bullet, gun.transform.position, Quaternion.identity);
        }
    }


    private void CheckSpaceShipOutOfBounds()
    {
        transform.position = new Vector3(
                    Mathf.Clamp(transform.position.x, -7.2f, 7.2f),
                    Mathf.Clamp(transform.position.y, -4.0f, 3.2f),
                    transform.position.z
                    );
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
