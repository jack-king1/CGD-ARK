using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGather : MonoBehaviour
{
    public List<GameObject> resources = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && resources.Count > 0)
        {
            for (int i = 0; i < resources.Count; i++)
            {
                Resource resourceScript = resources[i].GetComponent<Resource>();
                resourceScript.Collect();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "resource")
        {
            resources.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "resource")
        {
            resources.Remove(other.gameObject);
        }
    }
}
