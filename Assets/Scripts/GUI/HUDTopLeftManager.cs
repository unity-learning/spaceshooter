using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDTopLeftManager : MonoBehaviour
{
    public Text txtHealthPercent;
    public Text txtScore;

    public void SetScoreText(int score)
    {
        txtScore.text = score.ToString();
    }

    private void Start()
    {

    }


    void Update()
    {

    }
}
