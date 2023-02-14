using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRepository : MonoBehaviour
{
    public string RepositoryName { get { return repositoryName; } }

    private const string repositoryName = "coinRepository";

    private int coins;



    public int Get() { return coins; }

    public bool Pop(int count)
    {
        if (Has(count))
        {
            coins = coins - count;
            Save();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Push(int count)
    {
        if (count > 0)
        {
            coins = coins + count;
            Save();
        }
    }

    public void Save()
    {
        SaveRepository();
    }


    private void Start()
    {
        if (PlayerPrefs.HasKey(repositoryName))
        {
            coins = Retrive();
        }
        else
        {
            coins = 0;
        }
    }

    private int Retrive()
    {
        return PlayerPrefs.GetInt(repositoryName);
    }

    private void SaveRepository()
    {
        PlayerPrefs.SetInt(repositoryName, coins);
    }

    private bool Has(int count)
    {
        if (coins >= count)
        {
            return true;
        }

        return false;
    }
}
