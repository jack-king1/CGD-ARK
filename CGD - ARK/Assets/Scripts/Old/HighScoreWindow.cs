using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreWindow : MonoBehaviour
{
    public GameObject scoreBoard;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            scoreBoard.SetActive(!scoreBoard.activeSelf);
        }
    }
}

