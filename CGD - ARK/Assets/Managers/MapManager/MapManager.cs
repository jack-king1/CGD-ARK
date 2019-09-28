using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private int col;
    [SerializeField] private int row;
    private Vector2[][] tile_Positions;
    private GameObject[] tiles;

    private int col_height = 0;
    private int row_width = 0;


    private void Awake()
    {
        //Initialise Tile Positions.
        for (int i = 0; i < col; ++i)
        {
            for (int j = 0; j < row; ++j)
            {
                //Set New Tile Position

                //Set the X Positon - This ensures the middle is always 0,0.
                tile_Positions[i][j].x = row_width * i - (i * (col /2));

                //Set the Y Position
                tile_Positions[i][j].y = col_height * j;
            }
        }
    }
}
