using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventTypes;

//Require component ensures that this object has a type Player data attached, if not it adds one.
[RequireComponent(typeof(PlayerData))]
public class Movement : MonoBehaviour
{

    [Range(1.0f, 3.0f)]
    public float speed;
    private Rigidbody2D rigid;        

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void walk(MOVEMENT keypress)
    {
        switch(keypress)
        {
            case MOVEMENT.up:
                //code here
                break;
            case MOVEMENT.down:
                //code here
                break;
            case MOVEMENT.left:
                //code here
                break;
            case MOVEMENT.right:
                //code here
                break;
        }
    }


}
