using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResource : MonoBehaviour
{
    public int max_health;
    public float health;

    float health_rate = 0.5f;
    public float max_hunger;
    public float hunger;
    float hunger_rate = 1f;
    public float max_thirst;
    public float thirst;
    float thirst_rate = 1f;

    [SerializeField] private float starting_health;
    [SerializeField] private float starting_hunger;
    [SerializeField] private float starting_thirst;

    // Start is called before the first frame update
    void Start()
    {
        health = max_health;
        hunger = max_hunger;
        thirst = max_thirst;
    }

    void Update()
    {
        if (health < max_health && hunger > 0 && thirst > 0)
        {
            // When not at max health, gradually restore health and lose hunger at twice the rate
            health += health_rate * Time.deltaTime;
            hunger -= (hunger_rate * 2) * Time.deltaTime;
        }
        else
        {
            // Lose hunger gradually at normal rate
            if (hunger > 0)
            {
                hunger -= hunger_rate * Time.deltaTime;
            }
        }

        if (hunger <= 0 && health > 0)
        {
            // Lose health gradually if out of food
            health -= health_rate * Time.deltaTime;
        }

        if (thirst <= 0 && health > 0)
        {
            // Lose health gradually if out of water
            health -= health_rate * Time.deltaTime;
        }

        if (thirst > 0)
        {
            // Lose water gradually at normal rate
            thirst -= thirst_rate * Time.deltaTime;
        }
    }

    public void Eat(int val)
    {
        if (hunger < max_hunger)
        {
            if (hunger + val >= max_hunger)
            {
                hunger = max_hunger;
            }
            else
            {
                hunger += val;
            }
        }
    }

    public void Drink(int val)
    {
        if (thirst < max_thirst)
        {
            if (thirst + val >= max_thirst)
            {
                thirst = max_thirst;
            }
            else
            {
                thirst += val;
            }
        }
    }

    public void ResetPlayer()
    {
        health = starting_health;
        hunger = starting_hunger;
        thirst = starting_thirst;
    }

    //Getters
    public float getHealth()
    {
        return health;
    }

    public float getHunger()
    {
        return hunger;
    }

    public float getThirst()
    {
        return thirst;
    }

    //Setters
    public void setHealth(float _health)
    {
        health = _health;
    }

    public void setHunger(float _hunger)
    {
        hunger = _hunger;
    }

    public void setThirst(float _thirst)
    {
        thirst = _thirst;
    }
}
