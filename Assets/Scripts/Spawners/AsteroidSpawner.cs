using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject[] asteroidsPrefab;
    public Vector2 timeToSpawn;
    public Vector2 xAxisLimitToSpawn;

    void Start()
    {
        StartCoroutine("Spawn");
    }


    void Update()
    {
        
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(timeToSpawn.x, timeToSpawn.y));
        Vector2 newPos = transform.position;
        newPos.x = Random.Range(xAxisLimitToSpawn.x, xAxisLimitToSpawn.y);
        int rnd = Random.Range(0, asteroidsPrefab.Length);
        Instantiate(asteroidsPrefab[rnd], newPos, Quaternion.identity);
        StartCoroutine("Spawn");
    }
}
