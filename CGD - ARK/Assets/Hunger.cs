using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunger : MonoBehaviour
{
    [SerializeField] private float starting_hunger;
    [SerializeField] private float max_hunger;
    [SerializeField] private float hunger;
    [SerializeField] private float hunger_rate = 1f;

    public float startingHunger()
    {
        return starting_hunger;
    }

    public float maxHunger()
    {
        return max_hunger;
    }

    public float currentHunger()
    {
        return hunger;
    }

    public float hungerRate()
    {
        return hunger_rate;
    }

    public void maxHunger(float maxhunger)
    {
        max_hunger = maxhunger;
    }

    public void hungerRate(float hungerRate)
    {
        hunger_rate = hungerRate;
    }

    public void addHunger(float hunger_to_add)
    {
        hunger += hunger_to_add;
    }

    public void minusHunger(float hunger_to_lose)
    {
        hunger -= hunger_to_lose;
    }

    public void setHunger(float new_hunger)
    {
        hunger = new_hunger;
    }
}
