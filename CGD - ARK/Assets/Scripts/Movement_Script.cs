using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Script : MonoBehaviour
{
    [Range(0, 10)]
    public float moveSpeed = 8;

    public Rigidbody2D rigid;

    public Vector2 movement;

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //Constarints agaisnt diagonal movement
        if (movement.x == 1 || movement.x == -1)
        {
            movement.y = 0;
        }

        if (movement.y == 1 || movement.y == -1)
        {
            movement.x = 0;
        }


    }

    private void FixedUpdate()
    {
        rigid.MovePosition(rigid.position + movement * moveSpeed *Time.fixedDeltaTime);
    }
}
