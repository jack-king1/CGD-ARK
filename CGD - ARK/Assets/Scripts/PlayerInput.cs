using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventTypes;

public class PlayerInput : MonoBehaviour
{
    private Rigidbody2D rb;
    private Movement movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = gameObject.GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        //Keyboard Inputs
        if (InputManager.KeyW())
        {
            Debug.Log("W WAS PRESSED.");
            movement.walk(MOVEMENT.up);
        }

        if (InputManager.KeyA())
        {
            Debug.Log("A WAS PRESSED.");
            movement.walk(MOVEMENT.left);
        }

        if (InputManager.KeyS())
        {
            Debug.Log("S WAS PRESSED.");
            movement.walk(MOVEMENT.down);
        }

        if (InputManager.KeyD())
        {
            Debug.Log("D WAS PRESSED.");
            movement.walk(MOVEMENT.right);
        }
    }
}
