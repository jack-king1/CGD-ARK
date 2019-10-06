using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventTypes;

public class GameState : MonoBehaviour
{
    private SCENE_TYPE gameState;
    [SerializeField] private GameObject playerManager;
    [SerializeField] private GameObject audioManager;
    [SerializeField] private GameObject mapManager;

    public void initMenuScene()
    {
        //Stuff to do for menu initialization.
    }

    public void initGameScene()
    {
        //Stuff to do for Game Init.

        //Init map tiles
        //mapManager.GetComponent<MapManager>().init();

        //Spawn Player

    }

    public void initLeaderboardScene()
    {
        //Stuff to do for Leaderboard init.
    }
}
