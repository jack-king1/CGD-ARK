using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoSpawner : MonoBehaviour
{
    //need to get the bounds of the map for spawning dinasaurs.
    // Get tile [0], [tile row + tile height] get 1st and last tile.
    public Rect map_bounds;

    //reference to Mapmanager
    [SerializeField] private MapManager mapManager;

    private void Start()
    {
        mapManager = gameObject.GetComponent<MapManager>();
        Debug.Log("Calculating Bounds");
        Bounds();
    }

    void Bounds()
    {
        Debug.Log("Map Columns:" + mapManager.Columns());

        map_bounds = new Rect(
            0, 
            mapManager.GetTileTransform(mapManager.Columns()).position.x,
            mapManager.GetTileTransform((mapManager.Columns() * mapManager.Rows()) - mapManager.Columns()).position.y, 
            mapManager.GetTileTransform(mapManager.Columns() * mapManager.Rows()).position.y);

        Debug.Log("Map Bounds" + map_bounds.x + map_bounds.width + map_bounds.y + map_bounds.height);
    }
}
