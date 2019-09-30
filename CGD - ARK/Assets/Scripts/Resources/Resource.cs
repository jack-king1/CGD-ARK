using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventTypes;

public class Resource : MonoBehaviour
{
    public bool resource_available = true;
    public float respawn_time = 60;
    public int type = 0;
    private RESOURCETYPE m_resourceType = RESOURCETYPE.none; //Jack
    SpriteRenderer sprite;
    Color default_colour;
    Color resource_colour;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        default_colour = Color.white;

        if (type == 1)
        {
            resource_colour = Color.red;
            default_colour = Color.green;
        }

        if (type == 2)
        {
            resource_colour = Color.blue;
            default_colour = Color.grey;
        }

        sprite.color = resource_colour;
    }

    public void Collect()
    {
        StartCoroutine(RespawnSequence());
    }

    IEnumerator RespawnSequence()
    {
        resource_available = false;
        sprite.color = default_colour;
        yield return new WaitForSeconds(respawn_time);
        resource_available = true;
        sprite.color = resource_colour;
    }
} 