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
        resource_available = false;
        yield return new WaitForSeconds(respawn_time);
        resource_available = true;
    }
} 