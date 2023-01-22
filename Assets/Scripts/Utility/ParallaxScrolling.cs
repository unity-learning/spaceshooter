using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScrolling : MonoBehaviour
{
    public Vector2 speed;


    private Renderer renderer;


    private void Awake()
    {
        renderer = GetComponent<Renderer>();


    }
    void Start()
    {

    }

    private void Update()
    {   
        renderer.material.mainTextureOffset = Time.time * speed;
    }
}
