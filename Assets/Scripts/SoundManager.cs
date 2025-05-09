using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    public static SoundManager Instance { get { return instance; } }

    public AudioSource soundEffect;
    public AudioSource soundMusic;

    public SoundType[] sounds;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        PlayMusic(Sounds.BackgroundMusic);
    }

    public void PlayMusic(Sounds sound)
    {
        AudioClip clip = getSoundClip(sound);

        if (clip != null)
        {
            soundMusic.clip = clip;
            soundMusic.Play();
        }

        else
        {
            Debug.LogError("Problem occured. Audio could not play " + sound + " sound.");
        }
    }

    public void Play(Sounds sound)
    {
        AudioClip clip = getSoundClip(sound);

        if (clip != null)
        {
            soundEffect.clip = clip;
            soundEffect.Play();
        }

        else
        {
            Debug.LogError("Problem occured. Audio could not play " + sound + " sound.");
        }
    }

    private AudioClip getSoundClip(Sounds sound)
    {
        SoundType audio = Array.Find(sounds, item => item.soundType == sound);

        if (audio != null)
        {
            return audio.soundClip;
        }

        return null;
    }
}
