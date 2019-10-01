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
        
        Vector2 movement = new Vector2(InputManager.Horizontal(),
            InputManager.Vertical()).normalized;

        rb.velocity = (movement * m_speed * Time.fixedDeltaTime); 



        animator.SetFloat("Horizontal", rb.velocity.x);
        animator.SetFloat("Vertical", rb.velocity.y);
        animator.SetFloat("Speed", rb.velocity.magnitude);
      
    }

    public void Stop()
    {
        //rb.velocity = new Vector2(0f, 0f);
    }
}
