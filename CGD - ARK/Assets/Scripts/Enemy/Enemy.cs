using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventTypes;

//NOTE TO JACK: MOVE PATROL AUI INTO SEPERATE SCRIPT.

public class Enemy : MonoBehaviour
{
    [SerializeField] private bool chaseActive;
    [SerializeField] private GameObject player;
    [SerializeField] private float patrolDelay;
    [SerializeField] private float minPatrolDelay;
    [SerializeField] private float maxPatrolDelay;


    public Transform[] waypoints;
    [SerializeField] private int currentWaypointCount;
    [SerializeField] private Transform currentWaypoint;

    public float speed;
    public bool chasing;
    
    // Start is called before the first frame update
    void Start()
    {
        chasing = false;
        currentWaypoint = waypoints[StartingWaypoint()];
    }

    // Update is called once per frame
    void Update()
    {
        if(chasing)
        {
            Chase();
        }
        else
        {
            Patrol();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            player = collision.gameObject;
            //testing, please change sound
            AudioManager.instance.Play("Sisters");
            chasing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = null;
            //testing, please change sound
            AudioManager.instance.Stop("Sisters");
            chasing = false;
        }
    }

    void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, currentWaypoint.position, speed * Time.deltaTime);

        if (Vector2.Distance(gameObject.transform.position, currentWaypoint.transform.position) < 0.2f)
        {
            if(patrolDelay <= 0)
            {
                if(currentWaypointCount == waypoints.Length - 1)
                {
                    currentWaypointCount = 0;
                    currentWaypoint = waypoints[currentWaypointCount];
                }
                else
                {
                    currentWaypointCount += 1;
                    currentWaypoint = waypoints[currentWaypointCount];
                }
                setDelay();
            }
            else
            {
                patrolDelay -= Time.deltaTime;
            }
        }
    }

    void setDelay()
    {
        patrolDelay = Random.Range(minPatrolDelay, maxPatrolDelay);
    }

    int StartingWaypoint()
    {
        currentWaypointCount = Random.Range(0, waypoints.Length);
        return currentWaypointCount;
    }

}
