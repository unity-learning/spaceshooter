using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public Vector2 coinToSpawn;
    public GameObject coinPrefab;


    private void Start()
    {
        int countOfCoinsToSpawn = (int)Random.Range(coinToSpawn.x, coinToSpawn.y); ;
        for (int i = 0; i < countOfCoinsToSpawn; i++)
        {
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


    void Update()
    {
        
    }
}
