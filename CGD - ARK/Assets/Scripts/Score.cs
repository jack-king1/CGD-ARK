using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Text scoretext;
    public int CurrentScore;
    public float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 30)
        {
            CurrentScore += 13;
            timer = 0;
        }

       // CurrentScore++;
        scoretext.text = CurrentScore.ToString("0");
    }
}
