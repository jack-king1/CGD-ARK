using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public Text healthText;
    public Text hungerText;
    public Text thirstText;

    [SerializeField] private GameObject playerObject;
    [SerializeField] private Health health;
    [SerializeField] private Hunger hunger;
    [SerializeField] private Thirst thirst;



    // Start is called before the first frame update
    void Awake()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        health = playerObject.GetComponent<Health>();
        hunger = playerObject.GetComponent<Hunger>();
        thirst = playerObject.GetComponent<Thirst>();


        healthText.text = health.currentHealth().ToString();
        hungerText.text = hunger.currentHunger().ToString();
        thirstText.text = thirst.currentThirst().ToString();


    }

    private void Update()
    {
        //This should be done with events instead of polling/every frame. But im lazy and cba to put event manager in.
        //So we gunna poll this bitch. Heccys Job ;)

        //No floating point numbers - need to cast them to int.
        int temp_health = (int)health.currentHealth();
        int temp_hunger = (int)hunger.currentHunger();
        int temp_thirst = (int)thirst.currentThirst();

        healthText.text = temp_health.ToString();
        hungerText.text = temp_hunger.ToString();
        thirstText.text = temp_thirst.ToString();

        //Need score too.

    }

    public void updateGameUI()
    {
        healthText.text = health.currentHealth().ToString();
        hungerText.text = hunger.currentHunger().ToString();
        thirstText.text = thirst.currentThirst().ToString();
    }
}
