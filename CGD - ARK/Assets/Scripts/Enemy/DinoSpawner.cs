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
    [SerializeField] private int dinoCount;
    [SerializeField] private int maxDinoCount;
    private GameObject player;
    
    bool initialSpawn = false;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(!initialSpawn)
        {
            for(int i = 0; i < initialDinoAmount; ++i)
            {
                Vector3 spawnPos = RandomCircle(player.transform.position, RandomRadius());
                Instantiate(dinoPrefab, spawnPos, gameObject.transform.rotation);
            }
        }
    }

    private void Update()
    {
        //Spawn Dinos based on score and time in game.
        if(newDinoTimer <= 0)
        {
            //Spawn Dinos
            if(dinoCount < maxDinoCount)
            {
                ++dinoCount;
                Vector3 spawnPos = RandomCircle(player.transform.position, RandomRadius());
                Instantiate(dinoPrefab, spawnPos, gameObject.transform.rotation);
            }
        }
        else
        {
            newDinoTimer -= Time.deltaTime;
        }
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

    int calculateSpawnAmount()
    {
        return player.GetComponent<Score>().getScore() / 100;
    }

    int calculateSpawmRadiusMin()
    {
        return player.GetComponent<Score>().getScore() / 100;
    }

    public void decreaseDinoCount()
    {
        dinoCount--;
    }
}
