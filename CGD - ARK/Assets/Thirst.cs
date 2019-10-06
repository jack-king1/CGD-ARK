using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thirst : MonoBehaviour
{
    [SerializeField] private float starting_thirst;
    [SerializeField] private float max_thirst;
    [SerializeField] private float thirst;
    [SerializeField] private float thirst_rate = 1f;

    public float startingThirst()
    {
        return starting_thirst;
    }

    public float maxThirst()
    {
        return max_thirst;
    }

    public float currentThirst()
    {
        return thirst;
    }

    public float thirstRate()
    {
        return thirst_rate;
    }

    public void maxThirst(float maxthirst)
    {
        max_thirst = maxthirst;
    }

    public void thirstRate(float thirstRate)
    {
        thirst_rate = thirstRate;
    }

    public void addThirst(float thirst_to_add)
    {
        thirst += thirst_to_add;
    }

    public void minusThirst(float thirst_to_lose)
    {
        thirst -= thirst_to_lose;
    }

    public void setThirst(float new_thirst)
    {
        thirst = new_thirst;
    }
}
