using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Combat : MonoBehaviour
{
    [SerializeField] private float atkDelay;
    public float startAtkDelay;
    [SerializeField] private float damage;
    [SerializeField] private float damageMultiplier;


    public Transform atkPos;
    public float atkRadius;
    public LayerMask whatIsEnemy;
    public Collider2D[] thingsToDamage;

    private Health health;
    //This is incase we wanted to swap out different weapons in the future.
    // Maybe dinos could have a weapon or player can customise colour etc? long shot lool D:
    private GameObject[] weapons;
    private void Start()
    {
        health = gameObject.GetComponent<Health>();
        damage = damage * damageMultiplier;
    }

    private void Update()
    {
        if(gameObject.CompareTag("Player"))
        {
            if (atkDelay <= 0)
            {
                if (InputManager.Key_Space() || InputManager.NES_A())
                {
                    Debug.Log("Player Attacking");
                    thingsToDamage = Physics2D.OverlapCircleAll(atkPos.position, atkRadius, whatIsEnemy);
                    for (int i = 0; i < thingsToDamage.Length; ++i)
                    {
                        thingsToDamage[i].GetComponent<Combat>().TakeDamage(damage);
                    }
                }
                atkDelay = startAtkDelay;
            }
            else
            {
                atkDelay -= Time.deltaTime;
            }
        }
        else if(gameObject.CompareTag("Enemy"))
        {
            if (atkDelay <= 0)
            {
                if (gameObject.GetComponent<Enemy>().chasing)
                {
                    Debug.Log("Enemy Attacking");
                    thingsToDamage = Physics2D.OverlapCircleAll(atkPos.position, atkRadius, whatIsEnemy);
                    for (int i = 0; i < thingsToDamage.Length; ++i)
                    {
                        thingsToDamage[i].GetComponent<Combat>().TakeDamage(damage);
                    }
                }
                atkDelay = startAtkDelay;
            }
            else
            {
                atkDelay -= Time.deltaTime;
            }
        }

    }

    public void Attack()
    {

    }

    public void TakeDamage(float dmg)
    {

        Debug.Log("Taking Dmg: " + dmg);
        health.setHealth(health.currentHealth() - dmg);
        updateUI();
        Debug.Log("Current health: " + health.currentHealth());
        //Death noise rarawrda wdads
        if (health.currentHealth() <= 0)
        {
            Destroy(gameObject);
            if(gameObject.CompareTag("Player"))
            {
                //play player death sound
                AudioManager.instance.Play("PlayerDeath");
            }
            else
            {
                //play enemy death sound
                AudioManager.instance.Play("PlayerDeath");
            }
            AudioManager.instance.Play("PlayerDeath");
            //End game scene here with play again options.
        }
        int random = Random.Range(1, 4);
        if (random == 1)
        {
            AudioManager.instance.Play("attack_1");
        }
        else if (random == 2)
        {
            AudioManager.instance.Play("attack_2");
        }
        else if (random == 3)
        {
            AudioManager.instance.Play("attack_3");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(atkPos.position, atkRadius);
    }

    void Knockback()
    {

    }

    //Tell UI we have taken damage.
    public void updateUI()
    {

    }
}
