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

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void walk()
    {
            rb.velocity = new Vector2(InputManager.Horizontal() * (Time.fixedDeltaTime + m_speed), InputManager.Vertical() * (Time.fixedDeltaTime + m_speed));
    }

    public void stop()
    {
        //rb.velocity = new Vector2(0f, 0f);
    }
}
