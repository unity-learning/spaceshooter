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
    public GameObject[] guns;
    public int Health { get { return _health; } }
    public float fireRate = 0;
    public Animator flameAnimation;

    [SerializeField]
    private int _health;
    private float lastShot = 0;
    private const string FLAME_ANIMATION = "speed";


    private void Start()
    {
        
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(h, v, 0) * speed * Time.deltaTime;
        transform.position += move;
        flameAnimation.SetFloat(FLAME_ANIMATION, move.sqrMagnitude);
        CheckSpaceShipOutOfBounds();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    private void Fire()
    {
        if(Time.time > fireRate + lastShot) {
            for (int i = 0; i < guns.Length; i++)
            {
                Instantiate(bullet, guns[i].transform.position, Quaternion.identity);
            }
                lastShot = Time.time;
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
        if (collision.gameObject.tag == "BulletEnemy")
        {
            _health -= collision.gameObject.GetComponent<BulletController>().power;
            CheckHealth();
        }
        else if (collision.gameObject.tag == "Asteroid")
        {
            _health -= collision.gameObject.GetComponent<AsteroidController>().health;
            CheckHealth();
        }
        else if (collision.gameObject.tag == "ShipEnemy")
        {
            _health -= collision.gameObject.GetComponent<EnemyShipController>().power;
            CheckHealth();
        }
    }

    private void CheckHealth()
    {
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
