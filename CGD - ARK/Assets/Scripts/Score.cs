using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private int currentScore;
    [SerializeField] private float timeScoreSpeed;

    private void Update()
    {
        currentScore = (int)(gameObject.GetComponent<Timer>().timer * timeScoreSpeed);
        increaseScoreSpeed();
    }

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

    public void increaseScoreSpeed()
    {
        timeScoreSpeed += 0.001f;
    }
}
