using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public Text healthText;
    public Text hungerText;
    public Text thirstText;

    public PlayerResource resourceScript;

    // Start is called before the first frame update
    void Awake()
    {
        resourceScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerResource>();

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
