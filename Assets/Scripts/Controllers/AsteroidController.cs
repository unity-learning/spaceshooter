using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public float speed;
    public GameObject asteroid;
    public float rotationSpeed;
    public int health;
    public GameObject explosionPrefab;
    public Sprite[] healthSprite;
    public CoinSpawner coinSpawner;

    private Animator anim;
    private string ANIMATION_NAME = "health";
    private SpriteRenderer spriteRender;
    private GameController gameController;
    private int initHealth;

    private void Awake()
    {
        initHealth = health;
        anim = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();
        gameController = GameObject.FindObjectOfType<GameController>();
    }

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
        if (health <= 0)
        {
            gameController.AddScore(initHealth);
            int rnd = Random.Range(1, 2);
            if (rnd == 3)
            {
                Instantiate(coinSpawner, transform.position, Quaternion.identity);
            }
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            DoAnimationOrChangeSprite();
        }
    }

    private void ChangeSprite()
    {
        spriteRender.sprite = healthSprite[health - 1];
    }

    private void DoAnimationOrChangeSprite()
    {
        if (anim != null)
        {
            anim.SetInteger(ANIMATION_NAME, health);
        }
        else
        {
            ChangeSprite();
        }
    }


}
