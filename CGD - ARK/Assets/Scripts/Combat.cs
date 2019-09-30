using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    [SerializeField] private float atkDelay;
    public float startAtkDelay;
    [SerializeField] private float damage;
    [SerializeField] private float damageMultiplier;
    private PlayerResource pr;//This is just the data for enemies and player however they are kind of 1 atm.

    public Transform atkPos;
    public float atkRadius;
    public LayerMask whatIsEnemy;

    //This is incase we wanted to swap out different weapons in the future.
    // Maybe dinos could have a weapon or player can customise colour etc? long shot lool D:
    private GameObject[] weapons;
    private void Start()
    {
        damage = damage * damageMultiplier;
        pr = gameObject.GetComponent<PlayerResource>();
    }

    private void Update()
    {
        if(atkDelay <= 0)
        {
            if(InputManager.KeyDown_Space())
            {
                Collider2D[] thingsToDamage = Physics2D.OverlapCircleAll(atkPos.position, atkRadius, whatIsEnemy );
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
        pr.setHealth(pr.getHealth() - dmg);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(atkPos.position, atkRadius);
    }

}
