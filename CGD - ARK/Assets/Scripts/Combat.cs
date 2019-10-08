﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventTypes;

[RequireComponent(typeof(Health))]
public class Combat : MonoBehaviour
{
    [SerializeField] private float atkDelay;
    public float startAtkDelay;
    [SerializeField] private float damage;
    [SerializeField] private float damageMultiplier;
    private MapManager mapManager;
    [SerializeField] private float AtkDistance;


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
        mapManager = FindObjectOfType<MapManager>();
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
        health.setHealth(health.currentHealth() - dmg);
        //Death noise rarawrda wdads
        if (health.currentHealth() <= 0)
        {
            Destroy(transform.parent.gameObject);
            if(gameObject.CompareTag("Player"))
            {
                //play player death sound
                gameObject.GetComponent<Health>().setHealth(0);
                AudioManager.instance.Play("PlayerDeath");
                SceneLoader.changeScene(SCENE_TYPE.gameover_scene);
            }
            else
            {
                //play enemy death sound
                AudioManager.instance.Play("death");
                //Add score of enemy value
                GameObject.FindGameObjectWithTag("Player").GetComponent<Score>().addScore
                    (gameObject.GetComponent<Enemy>().scoreValue());
                mapManager.GetComponent<DinoSpawner>().decreaseDinoCount();
                
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
}
