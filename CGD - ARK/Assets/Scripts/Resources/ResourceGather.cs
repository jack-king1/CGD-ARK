using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGather : MonoBehaviour
{
    public List<GameObject> resources = new List<GameObject>();
    PlayerResource pl_resources;
    Score score;
    void Start()
    {
        pl_resources = GetComponent<PlayerResource>();
        score = GetComponent<Score>(); 
    }
    
    void Update()
    {
        if (InputManager.Key_Space() || InputManager.NES_A())
        {
            for (int i = 0; i < resources.Count; i++)
            {
                Resource resourceScript = resources[i].GetComponent<Resource>();
                if (resourceScript.resource_available)
                {
                    if (resourceScript.type == 1)
                    {
                        pl_resources.Eat(20);
                        AudioManager.instance.Play("eating");
                        score.addScore(113);
                    }
                    else if (resourceScript.type == 2)
                    {
                        pl_resources.Drink(20);
                        AudioManager.instance.Play("drink");
                        score.addScore(113);
                    }
                    else if (resourceScript.type == 3)
                    {
                        //player.ResourceScript.stone += 1;
                        AudioManager.instance.Play("pickup_1");
                    }
                    else if (resourceScript.type == 4)
                    {
                        //player.ResourceScript.wood += 1;
                        AudioManager.instance.Play("pickup_2");
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
