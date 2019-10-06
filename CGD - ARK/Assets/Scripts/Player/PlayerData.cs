using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventTypes;

public class PlayerData : MonoBehaviour
{

    [SerializeField] private float m_playerScore;
    [SerializeField] private PLAYERSTATE m_playerState;

    //Getters
    public float PlayerScore()
    {
        return m_playerScore;
    }

    public PLAYERSTATE PlayerState()
    {
        return m_playerState;
    }

    //Setters
    public void ResetPlayerScore()
    {
        m_playerScore = 0;
    }

    public void IncreasePlayerScore(float score)
    {
        m_playerScore += score;
    }

    public void PlayerState(PLAYERSTATE ps)
    {
        m_playerState = ps;
    }
}
