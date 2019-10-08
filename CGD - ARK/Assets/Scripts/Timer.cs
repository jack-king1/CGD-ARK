using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timer;

    private void Update()
    {
        timer += Time.deltaTime;
    }
}
