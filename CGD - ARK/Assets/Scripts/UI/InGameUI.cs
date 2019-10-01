using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public Text healthText;
    public Text hungerText;
    public Text thirstText;

    private GameObject player;
    private GameObject enemy;

    PlayerResource resourceScript;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        resourceScript = player.GetComponent<PlayerResource>();

        healthText.text = resourceScript.getHealth().ToString();
        hungerText.text = resourceScript.getHunger().ToString();
        thirstText.text = resourceScript.getThirst().ToString();
    }

    public void updateGameUI()
    {
        healthText.text = resourceScript.getHealth().ToString();
        hungerText.text = resourceScript.getHunger().ToString();
        thirstText.text = resourceScript.getThirst().ToString();
    }
}
