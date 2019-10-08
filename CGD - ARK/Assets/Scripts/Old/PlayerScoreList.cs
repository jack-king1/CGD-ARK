using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreList : MonoBehaviour
{
    public GameObject playerScoreEntryPrefab;

    Scoreboard scoreboard;

    int lastChangeCounter;

    // Use this for initialization
    void Start()
    {
        scoreboard = GameObject.FindObjectOfType<Scoreboard>();
        lastChangeCounter = scoreboard.GetChangeCounter();
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreboard == null)
        {
            Debug.LogError("You forgot to add the score manager component to a game object!");
            return;
        }

        if (scoreboard.GetChangeCounter() == lastChangeCounter)
        {
            // No change since last update!
            return;
        }

        lastChangeCounter = scoreboard.GetChangeCounter();


        while (this.transform.childCount > 0)
        {
            Transform c = this.transform.GetChild(0);
            c.SetParent(null); 
            Destroy(c.gameObject);
        }

        string[] names = scoreboard.GetPlayerNames();

        foreach (string name in names)
        {
            GameObject go = (GameObject)Instantiate(playerScoreEntryPrefab);
            go.transform.SetParent(this.transform);
            go.transform.Find("Username").GetComponent<Text>().text = name;
            go.transform.Find("HighScore").GetComponent<Text>().text = scoreboard.GetScore(name, "Score").ToString();
        }

    }

}
