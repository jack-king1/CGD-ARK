using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    [SerializeField] private float atkDelay;
    public float startAtkDelay;
    [SerializeField] private float damage;
    [SerializeField] private float damageMultiplier;
    [SerializeField] private PlayerResource playerResource;//This is just the data for enemies and player however they are kind of 1 atm.

    public Transform atkPos;
    public float atkRadius;
    public LayerMask whatIsEnemy;
    public Collider2D[] thingsToDamage;

    //This is incase we wanted to swap out different weapons in the future.
    // Maybe dinos could have a weapon or player can customise colour etc? long shot lool D:
    private GameObject[] weapons;
    private void Start()
    {
        damage = damage * damageMultiplier;
        playerResource = gameObject.GetComponent<PlayerResource>();
    }

    private void Update()
    {
        if(atkDelay <= 0)
        {
            if(InputManager.Key_Space() || InputManager.NES_A())
            {
                Debug.Log("Space Pressed");
                thingsToDamage = Physics2D.OverlapCircleAll(atkPos.position, atkRadius, whatIsEnemy );
                for(int i = 0; i < thingsToDamage.Length; ++i)
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

    public void Attack()
    {

    }

    public void TakeDamage(float dmg)
    {

        Debug.Log("Taking Dmg: " + dmg);
        playerResource.setHealth(playerResource.getHealth() - dmg);
        Debug.Log("Current health: " + playerResource.getHealth());
        //Death noise rarawrda wdads
        if (playerResource.getHealth() <= 0)
        {
            Destroy(gameObject);
            AudioManager.instance.Play("PlayerDeath");
        }
        Debug.Log("Current Health: " + playerResource.getHealth());
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

}
