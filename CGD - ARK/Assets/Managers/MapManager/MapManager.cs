using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField]private bool m_randomTiles;

    [SerializeField] private int m_numberOfColumns;
    [SerializeField] private int m_numberOfRows;

    private Vector2[][] tile_Positions;
    private GameObject[] tile_types;

    private int col_height = 0;
    private int row_width = 0;


    private void Awake()
    {
        //Initialise Tile Positions.
        for (int i = 0; i < m_numberOfColumns; ++i)
        {
            for (int j = 0; j < m_numberOfRows; ++j)
            {
                //Local Position For Readability
                Vector2 pos;

                //Set New Tile Position
                //Set the X Positon
                tile_Positions[i][j].x = row_width * i - (i * (m_numberOfColumns /2));
                pos.x = tile_Positions[i][j].x;

                //Set the Y Position
                tile_Positions[i][j].y = col_height * j - ( j * (m_numberOfRows / 2));
                pos.y = tile_Positions[i][j].y;

                Instantiate(tile_types[tile_selector()], new Vector2(pos.x, pos.y), Quaternion.identity);
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
            return Random.Range(0, tile_types.Length -1);
        }
    }
}
