using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public float speed;



    private Vector2 direction;



    private void Start()
    {
        direction = Vector2.up;
        direction.x = Random.Range(-4f, 4f);
        Invoke("GoDown", .4f);
    }


    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void GoDown()
    {
        direction.y *= -1;
        direction.x = 0;
    }
}
