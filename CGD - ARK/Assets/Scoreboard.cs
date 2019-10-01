using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreboard : MonoBehaviour

{   Dictionary<string, int> playerScores;
    // Start is called before the first frame update
    void Start()
    {
        playerScores = new Dictionary<string, int>();
    }

    void Init()
    {
        if(playerScores !=null )
        {
            return;
        }
    }
    public int GetScore(string username,   )
    {
        Init();
        if(playerScores.ContainsKey(username) == false)
        {
            return 0;
        }
   
        return playerScores [username];
      
    }

    public void SetScore (string username, int value)
    {
        Init();
        if(playerScores.ContainsKey (username) == false)
        {
            playerScores[username] = new Dictionary<string, int>();
        }
        playerScores[username] = value;
    }

    public void ChangeScore(string username, int value)
    {
        Init();
    }
}
