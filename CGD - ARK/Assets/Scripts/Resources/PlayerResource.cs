using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//To Do
//Ideally the health/hunger and thirst need to be in another script. e.g. PlayerData.
//Then we can use the script for other objects.
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Hunger))]
[RequireComponent(typeof(Thirst))]
public class PlayerResource : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private Hunger hunger;
    [SerializeField] private Thirst thirst;

    // Start is called before the first frame update
    void Start()
    {
        health = gameObject.GetComponent<Health>();
        hunger = gameObject.GetComponent<Hunger>();
        thirst = gameObject.GetComponent<Thirst>();
    }

    void Update()
    {
        if (health.currentHealth() < health.maxHealth() 
            && hunger.currentHunger() > 0 
            && thirst.currentThirst() > 0)
        {
            // When not at max health, gradually restore health and lose hunger at twice the rate
            health.addHealth(health.healthRate() * Time.deltaTime);
            hunger.minusHunger((hunger.hungerRate() * 2) * Time.deltaTime);
        }
        else
        {
            // Lose hunger gradually at normal rate
            if (hunger.currentHunger() > 0)
            {
                hunger.minusHunger(hunger.hungerRate() * Time.deltaTime);
            }
        }

        if (hunger.currentHunger() <= 0 && health.currentHealth() > 0)
        {
            // Lose health gradually if out of food
            health.minusHealth(health.healthRate() * Time.deltaTime);
        }

        if (thirst.currentThirst() <= 0 && health.currentHealth() > 0)
        {
            // Lose health gradually if out of water
            health.minusHealth(health.healthRate() * Time.deltaTime);
        }

        if (thirst.currentThirst() > 0)
        {
            // Lose water gradually at normal rate
            thirst.minusThirst(thirst.thirstRate() * Time.deltaTime);
        }
    }

    public void Eat(int val)
    {
        if (hunger.currentHunger() < hunger.maxHunger())
        {
            if (hunger.currentHunger() + val >= hunger.maxHunger())
            {
                hunger.setHunger(hunger.maxHunger());
            }
            else
            {
                hunger.addHunger(val);
            }
        }
    }

    public void Drink(int val)
    {
        if (thirst.currentThirst() < thirst.maxThirst())
        {
            if (thirst.currentThirst() + val >= thirst.maxThirst())
            {
                thirst.setThirst(thirst.maxThirst());
            }
            else
            {
                thirst.addThirst(val);
            }
        }
    }

    public void ResetPlayer()
    {
        health.setHealth(health.startingHealth());
        hunger.setHunger(hunger.startingHunger());
        thirst.setThirst(thirst.startingThirst());
    }
}
