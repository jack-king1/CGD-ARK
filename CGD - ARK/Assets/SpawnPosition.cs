using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPosition : MonoBehaviour
{
    public MapManager mapManager;
    [SerializeField] private float offsetX = 0;
    [SerializeField] private float offsetY = 0;
    void Start()
    {
        mapManager = FindObjectOfType<MapManager>();
        gameObject.transform.position = mapManager.GetBoundsCenter();
        Vector3 offsetPos = new Vector3(gameObject.transform.position.x + offsetX, 
            gameObject.transform.position.y + offsetY, 
            gameObject.transform.position.z);
        gameObject.transform.position = offsetPos;
    }
}
