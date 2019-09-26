using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventTypes;

//Require component ensures that this object has a type Player data attached, if not it adds one.
[RequireComponent(typeof(PlayerData))]
public class Movement : MonoBehaviour
{

    [Range(1.0f, 3.0f)]
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
        if(InputManager.Vertical() > 0 || InputManager.Vertical() < 0)
        {
            rb.velocity = new Vector2(0, InputManager.Vertical() * (Time.fixedDeltaTime + m_speed));
        }

        if(InputManager.Horizontal() > 0 || InputManager.Horizontal() < 0)
        {
            rb.velocity = new Vector2(InputManager.Horizontal() * (Time.fixedDeltaTime + m_speed), 0 );
        }
        
        
    }

    public void Stop()
    {
        //rb.velocity = new Vector2(0f, 0f);
    }
}
