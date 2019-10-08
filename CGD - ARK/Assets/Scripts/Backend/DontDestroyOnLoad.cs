using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
   void Awake()
    {
        DontDestroyOnLoad(this);
        if (GameObject.Find("GameManager"))
        {
            Destroy(this);
        }
    }
}
