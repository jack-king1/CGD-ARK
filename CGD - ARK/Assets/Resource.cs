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

        //just thought i would cahnge it to enums and switch - Jack - delete if you dont wannt it i commented it out incase of merge errors.
        //switch(m_resourceType)
        //{
        //    case RESOURCETYPE.hunger:
        //        //code here.
        //        break;
        //    case RESOURCETYPE.thirst:
        //        //code here
        //        break;
        //    case RESOURCETYPE.stone:
        //        //code here
        //        break;
        //    case RESOURCETYPE.wood:
        //        //code here
        //        break;
        //    default:
        //        break;
        //}

    }

    IEnumerator RespawnSequence()
    {
        yield return new WaitForSeconds(respawn_time);
        resource_available = true;
    }
} 