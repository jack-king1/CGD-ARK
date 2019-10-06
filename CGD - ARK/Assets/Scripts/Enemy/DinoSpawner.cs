using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoSpawner : MonoBehaviour
{
    //Spawn enemies around player.
    //The more score the player has the closer the enemies spawn.
    //The longer the game has gone on the more enemies spawn.
    [SerializeField] private GameObject dinoPrefab;
    [SerializeField] private float newDinoTimer = 0.0f;
    [SerializeField] private int initialDinoAmount;
    [SerializeField] private float spawnRadiusMin;
    [SerializeField] private float spawnRadiusMax;
    private Transform playerTransform;

    bool initialSpawn = false;
    
    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        if(!initialSpawn)
        {
            for(int i = 0; i < initialDinoAmount; ++i)
            {
                Vector3 spawnPos = RandomCircle(playerTransform.position, RandomRadius());
                Instantiate(dinoPrefab, spawnPos, gameObject.transform.rotation);
            }
        }
    }

    private void Update()
    {
        //Spawn Dinos based on score and time in game.
    }

    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;

        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = dinoPrefab.transform.position.z;
        return pos;
    }

    float RandomRadius()
    {
        return Random.Range(spawnRadiusMin, spawnRadiusMax);
    }
}
