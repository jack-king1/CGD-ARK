using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventTypes;

//Require component ensures that this object has a type Player data attached, if not it adds one.
public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    float Movementx;
    float Movementy;
    public GameObject weapon;

    [SerializeField] private float m_speed;

    public Animator animator;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void walk()
    {
        rb.velocity =
        new Vector2(InputManager.Horizontal() * (Time.fixedDeltaTime + m_speed),
            InputManager.Vertical() * (Time.fixedDeltaTime + m_speed));

        animator.SetFloat("Horizontal", rb.velocity.x);
        animator.SetFloat("Vertical", rb.velocity.y);
        animator.SetFloat("Speed", rb.velocity.magnitude);
    }

    public void attack()

    {
        if (animator.GetFloat("Horizontal") < -1)
        {
            weapon.
        }


    }

    public void Stop()
    {
        //rb.velocity = new Vector2(0f, 0f);
    }
}
