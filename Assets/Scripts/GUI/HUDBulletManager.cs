using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDBulletManager : MonoBehaviour
{
    public Text txtBullets;
    public int dangerBulletCount;
    public Sprite blueBullet;
    public Sprite redBullet;
    
    private Image imageMainHud;


    public void SetBulletText(int b)
    {
        txtBullets.text = b.ToString();
    }

    private void Start()
    {

    }


    private void Update()
    {

    }
}
