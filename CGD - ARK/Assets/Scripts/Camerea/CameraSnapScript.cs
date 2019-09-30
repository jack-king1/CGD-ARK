using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSnapScript : MonoBehaviour
{
    [SerializeField] private Camera m_mainCamera;

    private void Awake()
    {
        m_mainCamera = Camera.main;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Tile"))
        {
            Debug.Log("Player Entered New Tile");
            m_mainCamera.transform.position = new Vector3(collision.transform.position.x, 
                collision.transform.position.y, 
                m_mainCamera.transform.position.z);
        }
    }
}
