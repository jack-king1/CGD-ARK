using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    [SerializeField] private float damageDelay;
    [SerializeField] private float damage;
    [SerializeField] private float damageMultiplier;


    private void Start()
    {
        damage = damage * damageMultiplier;    
    }

}
