using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Text scoretext;
    public int CurrentScore;
       
    
    // Update is called once per frame
    void Update()
    {
        CurrentScore++;
        scoretext.text = CurrentScore.ToString("0");
    }
}
