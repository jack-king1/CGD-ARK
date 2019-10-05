using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float starting_health;
    [SerializeField] private float max_health;
    [SerializeField] private float health;
    [SerializeField] private float health_rate = 0.5f;

    public float startingHealth()
    {
        return starting_health;
    }

    public float maxHealth()
    {
        return max_health;
    }

    public float currentHealth()
    {
        return health;
    }

    public float healthRate()
    {
        return health_rate;
    }

    public void maxHealth(float maxHealth)
    {
        max_health = maxHealth;
    }

    public void healthRate(float healthRate)
    {
        health_rate = healthRate;
    }

    public void addHealth(float health_to_add)
    {
        health += health_to_add;
    }

    public void minusHealth(float health_to_lose)
    {
        health -= health_to_lose;
    }
    public void setHealth(float new_health)
    {
        health = new_health;
    }
}
