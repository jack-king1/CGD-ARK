using System.Collections;
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
        return Mathf.Clamp(r, -1.0f, 1.0f);
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

    public static float Horizontal()
    {
        float r = 0.0f;
        r = Input.GetAxis("Horizontal");
        return r;
    }
    public static float Vertical()
    {
        float r = 0.0f;
        r = Input.GetAxis("Vertical");
        return r;
    }

    public static bool KeyReleased_W()
    {
        return Input.GetButtonUp("Key_W");
    }

    public static bool KeyReleased_S()
    {
        return Input.GetButtonUp("Key_S");
    }

    public static bool KeyReleased_A()
    {
        return Input.GetButtonUp("Key_A");
    }

    public static bool KeyReleased_D()
    {
        return Input.GetButtonUp("Key_D");
    }

    public static bool KeyUp_Enter()
    {
        return Input.GetButtonUp("Key_Enter");
    }

    public static bool Key_Space()
    {
        return Input.GetButton("Key_Space");
    }
}
