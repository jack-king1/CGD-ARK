using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : Movement
{
    public GameObject axe_Up;
    public GameObject axe_Left;
    public GameObject axe_Right;

    private void Awake()
    {
        axe_Left.SetActive(false);
        axe_Right.SetActive(false);
        axe_Up.SetActive(true);
    }
    private void Update()
    {
        //if( animator.GetFloat("Horizontal") < 0.01 || 
        //    animator.GetFloat("Horizontal") >0.01)
        //{
        //    axe_Left.SetActive(false);
        //    axe_Right.SetActive(false);
        //    axe_Up.SetActive(true);
        //}

        //if (animator.GetFloat("Vertical") < -0.01)
        //{
        //    axe_Left.SetActive(true);
        //    axe_Right.SetActive(false);
        //    axe_Up.SetActive(false);
        //}

        //if (animator.GetFloat("Vertical") >0.01)
        //{
        //    axe_Left.SetActive(false);
        //    axe_Right.SetActive(true);
        //    axe_Up.SetActive(false);
        //}


        if (animator.GetFloat("Vertical") == 0 &&
            animator.GetFloat("Horizontal") <= -0.1)
        {
            axe_Left.SetActive(true);
            axe_Right.SetActive(false);
            axe_Up.SetActive(false);
        }

        if (animator.GetFloat("Vertical") == 0 &&
           animator.GetFloat("Horizontal") >= 0.1)
        {
            axe_Left.SetActive(false);
            axe_Right.SetActive(true);
            axe_Up.SetActive(false);
        }

        if (animator.GetFloat("Vertical") <= -0.1|| 
            animator.GetFloat("Vertical") >= 0.1 &&
          animator.GetFloat("Horizontal") == 0 || 
          animator.GetFloat("Horizontal") == 0)
        {
            axe_Left.SetActive(false);
            axe_Right.SetActive(false);
            axe_Up.SetActive(true);
        }

       
    }
}
