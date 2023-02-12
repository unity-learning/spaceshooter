using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int Score
    {
        get { return score; }
    }

    public HUDTopLeftManager hudTopLeftManager;
    public HUDBulletManager hudBulletManager;

    private int score; // score of player
    private int bullets = 100;
    private int coins;


    public void AddScore(int s)
    {
        if (score > 0)
        {
            score += s;
            hudTopLeftManager.SetScoreText(score);
        }
    }

    public void PopBullet()
    {
        bullets = bullets - 1;
        hudBulletManager.SetBulletText(bullets);
    }

    public bool HasBullet()
    {
        if (bullets > 0) return true;
        return false;
    }

    public void AddCoin()
    {
        coins += 1;
    }

    private void Start()
    {
        score = 1;
        coins = 0;
        bullets = 100;
        hudTopLeftManager.SetScoreText(score);
        hudBulletManager.SetBulletText(bullets);
    }


    private void Update()
    {

    }

    private void OnApplicationQuit()
    {
        coins = coins + PlayerPrefs.GetInt("coin");
        PlayerPrefs.SetInt("coin", coins);
    }


}
