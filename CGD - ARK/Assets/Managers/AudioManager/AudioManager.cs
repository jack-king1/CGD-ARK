using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

/// <summary>
///  Singleton Class - Only one instance of this script will exist.
/// </summary>

//To access the audio manager in another script just type AudioManager.Play("Sound Name Here");
// To add more sounds go to Unity -> Select AudiManager Script which will be attached to GameManager, Increase Array Size by 1 and add drag sound into it.

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    private void Start()
    {
        Play("Test");
        FadeIn("Test", 1, 5.0f);
    }

    public void Play(string sound_name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == sound_name);
        if (s == null)
        {
            Debug.Log("Sound with name: " + sound_name + " was not found.");
            return;
        }
        s.source.Play();
    }

    public void Stop(string sound_name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == sound_name);
        if (s == null)
        {
            Debug.Log("Sound with name: " + sound_name + " was not found.");
            return;
        }
        s.source.Stop();
    }

    public void FadeIn(string sound_name, float volume, float time)
    {
        float interpolater = 0.0f;
        Sound s = Array.Find(sounds, sound => sound.name == sound_name);
        //if(s.volume < volume)
        //{
        //    interpolater += Time.deltaTime;
        //    s.volume = Mathf.Lerp(s.volume, volume, interpolater);
        //}
    }

    public void FadeOut(string sound_name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == sound_name);
        while (s.volume > 0)
        {
            s.volume -= 0.1f * Time.deltaTime;
        }
    }
}

