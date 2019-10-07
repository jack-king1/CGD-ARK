using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuddleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject puddlePrefab;
    private MapManager mapManager;
    [SerializeField] private int puddleAmount;
    [SerializeField] private float spawnRadiusMin;
    [SerializeField] private float spawnRadiusMax;

    private void Start()
    {
        mapManager = gameObject.GetComponent<MapManager>();
        for (int i = 0; i < puddleAmount; ++i)
        {
            Vector3 spawnPos = RandomCircle(mapManager.GetBoundsCenter(), RandomRadius());
            Instantiate(puddlePrefab, spawnPos, gameObject.transform.rotation);
        }
    }

    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;

        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = puddlePrefab.transform.position.z;
        return pos;
    }

    float RandomRadius()
    {
        return Random.Range(spawnRadiusMin, spawnRadiusMax);
    }
}
