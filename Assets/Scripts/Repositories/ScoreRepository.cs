using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRepository : MonoBehaviour
{


    private const string lastScoreRepository = "lastScoreRepository";
    private const string highScoreRepository = "highScoreRepository";

    private int scores;

    public void Push(int score)
    {
        SaveRepository(lastScoreRepository, score);
        int lastScore = Retrive(lastScoreRepository);
        if (score > lastScore)
        {
            SaveRepository(highScoreRepository, score);
        }
    }

    public int GetLastScore()
    {
        return Retrive(lastScoreRepository);
    }

    public int GetHighScore()
    {
        return Retrive(highScoreRepository);
    }


    private void Start()
    {

    }

    private int Retrive(string key)
    {
        return PlayerPrefs.GetInt(key);
    }

    private void SaveRepository(string key, int val)
    {
        PlayerPrefs.SetInt(key, val);
    }
}
