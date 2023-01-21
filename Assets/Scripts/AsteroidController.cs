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


    private Animator anim;
    private string ANIMATION_NAME = "health";
    private SpriteRenderer spriteRender;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();
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
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        } else
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
