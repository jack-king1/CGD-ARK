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
    SpriteRenderer sprite_rend;
    public Sprite empty_spr;
    public Sprite full_spr;

    void Start()
    {
        sprite_rend = GetComponent<SpriteRenderer>();
    }

    public void Collect()
    {
        StartCoroutine(RespawnSequence());
    }

    IEnumerator RespawnSequence()
    {
        resource_available = false;
        sprite_rend.sprite = empty_spr;
        yield return new WaitForSeconds(respawn_time);
        resource_available = true;
        sprite_rend.sprite = full_spr;
    }
} 