using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BulletDirection { UP, DOWN }


public class BulletController : MonoBehaviour
{
    public float speed = 10.0f;
    public BulletDirection direction;
    public GameObject explosionPrefab;
    public int power;
    public Sprite[] sprites;

    private Vector3 move = Vector3.down;
    [SerializeField]
    private SpriteRenderer spriteRenderer;


    private void Start()
    {

        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

        if (direction == BulletDirection.DOWN)
        {
            move = Vector3.down;
        }
        else
        {
            move = Vector3.up;
        }
    }


    private void Update()
    {
        transform.Translate(move * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explosionPrefab, collision.contacts[0].point, Quaternion.identity);
        Destroy(gameObject);
    }
}
