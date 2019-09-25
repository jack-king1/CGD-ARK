﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script will handle all inputs from all different kinds of devices.

public static class InputManager
{
    //Axis

    public static float JoystickHorizontal(int player_id)
    {
        float r = 0.0f;
        r += Input.GetAxis("J_Horizontal_" + player_id.ToString());
        r += Input.GetAxis("K_Horizontal_" + player_id.ToString());
        return Mathf.Clamp(r, -1.0f, 1.0f);;
    }
    public static float JoystickVertical(int player_id)
    {
        float r = 0.0f;
        r += Input.GetAxis("J_Vertical_" + player_id.ToString());
        r += Input.GetAxis("K_Vertical_" + player_id.ToString());
        return r;
    }

    //Buttons
    public static bool AButton(int player_id)
    {
        return Input.GetButtonDown("A_Button_" + player_id.ToString());
    }

    public static bool AButtonUp(int player_id)
    {
        return Input.GetButtonUp("A_Button_" + player_id.ToString());
    }

    public static bool BButton(int player_id)
    {
        return Input.GetButtonDown("B_Button_" + player_id.ToString());
    }

    public static bool XButton(int player_id)
    {
       
        return Input.GetButtonDown("X_Button_" + player_id.ToString());
    }

    public static bool XButtonUp(int player_id)
    {
        return Input.GetButtonUp("X_Button_" + player_id.ToString());
    }

    public static bool YButton(int player_id)
    {
        return Input.GetButtonDown("Y_Button_" + player_id.ToString());
    }

    public static bool KeyW()
    {
        return Input.GetKey(KeyCode.W);
    }

    public static bool KeyA()
    {
        return Input.GetKey(KeyCode.A);
    }

    public static bool KeyS()
    {
        return Input.GetKey(KeyCode.S);
    }

    public static bool KeyD()
    {
        return Input.GetKey(KeyCode.D);
    }
}