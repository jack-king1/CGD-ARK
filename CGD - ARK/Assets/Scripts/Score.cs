using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private int currentScore;

    public void addScore(int score)
    {
        currentScore += score;
    }

    public int getScore()
    {
        return currentScore;
    }

    public void ResetScore()
    {
        currentScore = 0;
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("score", currentScore);
    }
}
