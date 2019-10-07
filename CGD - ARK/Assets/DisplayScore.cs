using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    int end_score = 0;
    Text score_text;

    // Start is called before the first frame update
    void Start()
    {
        score_text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score_text.text = "Score: " + end_score;
    }

    void OnEnable()
    {
        end_score = PlayerPrefs.GetInt("score");
    }
}
