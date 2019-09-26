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

    public void walk(MOVEMENT keypress)
    {
        switch(keypress)
        {
            case MOVEMENT.up:
                rb.velocity = new Vector2(0, 1.0f  * (Time.fixedDeltaTime + m_speed));

                break;
            case MOVEMENT.down:
                rb.velocity = new Vector2(0, -1.0f * (Time.fixedDeltaTime + m_speed));
                break;
            case MOVEMENT.left:
                rb.velocity = new Vector2(-1.0f * (Time.fixedDeltaTime + m_speed), 0);
                break;
            case MOVEMENT.right:
                rb.velocity = new Vector2(1.0f * (Time.fixedDeltaTime + m_speed), 0 );
                break;
        }
    }

    public void Stop()
    {
        rb.velocity = new Vector2(0f, 0f);
    }
}
