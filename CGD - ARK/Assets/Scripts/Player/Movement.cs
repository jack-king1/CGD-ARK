using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventTypes;

//Require component ensures that this object has a type Player data attached, if not it adds one.
public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float m_speed;

    public Animator animator;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void walk()
    {
        float horizontal_movement;
        float vertical_movement; 

        horizontal_movement = InputManager.Horizontal();
        vertical_movement = InputManager.Vertical();

        Vector2 movement = new Vector2(horizontal_movement, vertical_movement);

        if (InputManager.KeyReleased_W() || InputManager.KeyReleased_A() || InputManager.KeyReleased_S() || InputManager.KeyReleased_D())
        {
            horizontal_movement = 0;
            vertical_movement = 0;
            movement = new Vector2(horizontal_movement, vertical_movement);
            Stop();
        }

        animator.SetFloat("Horizontal", rb.velocity.x);
        animator.SetFloat("Vertical", rb.velocity.y);
        animator.SetFloat("Speed", rb.velocity.magnitude);

        rb.velocity = (movement.normalized * m_speed * Time.fixedDeltaTime);
    }

    public void Stop()
    {
        rb.velocity = new Vector2(0f, 0f);
    }
}
