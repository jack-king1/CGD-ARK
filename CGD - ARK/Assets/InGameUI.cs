using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public Text healthText;
    public Text foodText;
    public Text waterText;

    private GameObject player;
    private GameObject enemy;

    PlayerResource resourceScript;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        resourceScript = player.GetComponent<PlayerResource>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = Mathf.RoundToInt(resourceScript.health).ToString();
        waterText.text = Mathf.RoundToInt(resourceScript.thirst).ToString();
        foodText.text = Mathf.RoundToInt(resourceScript.hunger).ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            resourceScript.health--;
        }
    }

   
    
}
