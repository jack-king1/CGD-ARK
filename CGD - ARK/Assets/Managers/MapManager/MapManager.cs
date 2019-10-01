using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField]private bool m_randomTiles;

    [SerializeField] private int m_numberOfColumns;
    [SerializeField] private int m_numberOfRows;

    [SerializeField] private Transform[] tile_Positions;
    public GameObject[] tile_types;

    private int col_height = 0;
    private int row_width = 0;

    //Fixing
    float width = 8.33f;
    float height = 9.99f;

    public void Awake()
    {
        tile_Positions = new Transform[m_numberOfColumns * m_numberOfRows];
        int tile_count = 0;
        //Create Tiles
        for (float i = 0; i < m_numberOfColumns; ++i)
        {
            for (float j = 0; j < m_numberOfRows; ++j)
            {
                GameObject temp_tile = tile_types[tile_selector()];

                Instantiate(temp_tile, new Vector2(i * width,
                            j * height), Quaternion.identity);

                int current_tile = tile_count;

                tile_Positions[current_tile] = temp_tile.transform;
                ++tile_count;
            }
        }
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

    public Transform GetTileTransform(int tile_number)
    {
        return tile_Positions[tile_number].transform;
    }

    public int Columns()
    {
        return m_numberOfColumns;
    }

    public int Rows()
    {
        return m_numberOfRows;
    }
}
