using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGather : MonoBehaviour
{
    public List<GameObject> resources = new List<GameObject>();
    PlayerResource pl_resources;

    void Start()
    {
        pl_resources = GetComponent<PlayerResource>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            for (int i = 0; i < resources.Count; i++)
            {
                Resource resourceScript = resources[i].GetComponent<Resource>();
                if (resourceScript.resource_available)
                {
                    if (resourceScript.type == 1)
                    {
                        pl_resources.Eat(20);
                    }
                    else if (resourceScript.type == 2)
                    {
                        pl_resources.Drink(20);
                    }
                    else if (resourceScript.type == 3)
                    {
                        //player.ResourceScript.stone += 1;
                    }
                    else if (resourceScript.type == 4)
                    {
                        //player.ResourceScript.wood += 1;
                    }

                    resourceScript.Collect();
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.gameObject.tag == "resource")
        {
            Debug.Log("Enter");
            resources.Add(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "resource")
        {
            resources.Remove(other.gameObject);
        }
    }
}
