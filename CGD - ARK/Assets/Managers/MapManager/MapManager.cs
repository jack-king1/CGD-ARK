using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField]private bool m_randomTiles;

    [SerializeField] private int m_numberOfColumns;
    [SerializeField] private int m_numberOfRows;

    private Vector2[][] tile_Positions;
    public GameObject[] tile_types;

    private int col_height = 0;
    private int row_width = 0;

    //Fixing
    float width = 8.33f;
    float height = 9.99f;

    private void Awake()
    {
        //Create Tiles
        for (float i = 0; i < m_numberOfColumns; ++i)
        {
            for (float j = 0; j < m_numberOfRows; ++j)
            {
                GameObject temp_tile = tile_types[tile_selector()];

                //Getting wierd behaviour so hard coded numbers, please dont change
                //Instantiate(temp_tile, new Vector2(i * temp_tile.GetComponent<TileData>().Width(), 
                //    j * temp_tile.GetComponent<TileData>().Height()), Quaternion.identity);

                Instantiate(temp_tile, new Vector2(i * width,
                            j * height), Quaternion.identity);
            }
        }
        //After tiles have been instantiated call the camera setup function which
        // Places camera positions


    }

    int tile_selector()
    {
        if(!m_randomTiles)
        {
            return 0;
        }
        else
        {
            return Random.Range(0, tile_types.Length);
        }
    }
}
