using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileData : MonoBehaviour
{
    private float tile_centre;
    private Vector2 tile_positons;
    private float tile_width = 8.331f;
    private float tile_height = 9.99f;

    //Getters
    public Vector2 getPositon()
    {
        return new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
    }

    public Vector2 getCentre()
    {
        //Gets the centre position of this tile by dividing the length an height by 2.
        return new Vector2(
            gameObject.GetComponent<BoxCollider2D>().bounds.size.x / 2,
            gameObject.GetComponent<BoxCollider2D>().bounds.size.y / 2);
    }

    public float Width()
    {
        return tile_width;
    }

    public float Height()
    {
        return tile_height;
    }



    //Setters
    public void setPositon(Vector2 pos)
    {
        gameObject.transform.position = new Vector2(pos.x, pos.y);
    }
}
