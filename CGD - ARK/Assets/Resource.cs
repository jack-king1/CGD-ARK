using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public bool resource_available = true;
    public float respawn_time = 60;
    public int type = 0;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Collect()
    {
        if (type == 1)
        {
            //player.ResourceScript.hunger += 20;
        }
        else if (type == 2)
        {
            //player.ResourceScript.thirst += 20;
        }
        else if (type == 3)
        {
            //player.ResourceScript.stone += 1;
        }
        else if (type == 4)
        {
            //player.ResourceScript.wood += 1;
        }

        else if (type == 3)
        resource_available = false;
        StartCoroutine(RespawnSequence());
    }

    IEnumerator RespawnSequence()
    {
        yield return new WaitForSeconds(respawn_time);
        resource_available = true;
    }
} 