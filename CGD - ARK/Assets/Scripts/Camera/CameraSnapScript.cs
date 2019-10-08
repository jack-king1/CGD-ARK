using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSnapScript : MonoBehaviour
{
    private Camera m_mainCamera;

    private void Awake()
    {
        m_mainCamera = Camera.main;
    }

    public void snapCamera(Vector3 new_pos)
    {
            Debug.Log("Camera changing position: " + new_pos);
            m_mainCamera.transform.position = new Vector3(new_pos.x, 
                new_pos.y, 
                m_mainCamera.transform.position.z);
    }
}
