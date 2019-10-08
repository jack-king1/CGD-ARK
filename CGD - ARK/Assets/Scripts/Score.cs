using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private int currentScore;
    private int timerScore;
    private int killScore;
    [SerializeField] private float timeScoreSpeed;
    private int dinosKilled;

    private void Update()
    {
        timerScore = (int)(gameObject.GetComponent<Timer>().timer * timeScoreSpeed);
        currentScore = timerScore + killScore;
        increaseScoreSpeed();
    }

    public void addScore(int score)
    {
        killScore += score;
    }

    public int getScore()
    {
        return currentScore;
    }

    public void ResetScore()
    {
        timerScore = 0;
        killScore = 0;
        currentScore = 0;
    }

    public void increaseScoreSpeed()
    {
        timeScoreSpeed += 0.001f;
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("score", currentScore);
    }
}
