using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This manager will spawn the player in the middle of the map tiles, will only do it once the player game has entered the scene.

public class PlayerManager : MonoBehaviour
{
    public GameObject playerPrefab;

    void CreatePlayer()
    {
        //This needs to be the centre of the map using the mapManager get middle function.
        Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
