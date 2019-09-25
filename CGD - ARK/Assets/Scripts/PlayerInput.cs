using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Keyboard Inputs
        if (InputManager.KeyW())
        {
            Debug.Log("W WAS PRESSED.");
        }

        if (InputManager.KeyA())
        {
            Debug.Log("A WAS PRESSED.");
        }

        if (InputManager.KeyS())
        {
            Debug.Log("S WAS PRESSED.");
        }

        if (InputManager.KeyD())
        {
            Debug.Log("D WAS PRESSED.");
        }
    }
}
