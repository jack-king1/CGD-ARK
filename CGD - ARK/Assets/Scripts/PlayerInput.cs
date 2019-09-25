using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventTypes;

public class PlayerInput : MonoBehaviour
{
    private Rigidbody2D rb;
    private Movement movement;
    private PlayerData pd;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = gameObject.GetComponent<Movement>();
        pd = gameObject.GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        //Keyboard Inputs
        switch(pd.PlayerState())
        {
            case PLAYERSTATE.walking:
                Walk();
                break;
            case PLAYERSTATE.gathering:
                Gather();
                break;
            case PLAYERSTATE.attacking:
                Attack();
                break;
            default:
                break;
        }
    }

    void Walk()
    {
        if (InputManager.KeyW())
        {
            Debug.Log("W WAS PRESSED.");
            movement.walk(MOVEMENT.up);
        }
        else if (InputManager.KeyA())
        {
            Debug.Log("A WAS PRESSED.");
            movement.walk(MOVEMENT.left);
        }
        else if (InputManager.KeyS())
        {
            Debug.Log("S WAS PRESSED.");
            movement.walk(MOVEMENT.down);
        }
        else if (InputManager.KeyD())
        {
            Debug.Log("D WAS PRESSED.");
            movement.walk(MOVEMENT.right);
        }

    }

    void Gather()
    {

    }

    void Attack()
    {

    }
}
