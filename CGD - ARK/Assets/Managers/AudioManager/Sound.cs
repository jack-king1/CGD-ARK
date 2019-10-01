using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public AudioClip clip;
    public string name;
    [Range(0.0f, 20.0f)]
    public float volume;

    [Range(0.1f,20.0f)]
    public float pitch;

    [Range(0.1f, 5.0f)]
    public float fadeInTime;

    [Range(0.1f, 5.0f)]
    public float fadeOutTime;

    public bool loop;

    [HideInInspector]
    public AudioSource source;

}
