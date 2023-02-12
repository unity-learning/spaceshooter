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

    private int score; // score of player


    public void AddScore(int s)
    {
        if (score > 0) {
            score += s;
            hudTopLeftManager.SetScoreText(score);
        }
    }

    private void Start()
    {
        hudTopLeftManager.SetScoreText(score);
    }


    private void Update()
    {

    }


}
