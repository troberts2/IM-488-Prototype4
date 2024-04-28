using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;

    public Sound[] musicSounds, sfxSounds, Vasounds;
    public AudioSource musicSource, sfxSource, VASource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("Music_Test");
    }
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not found nerd");
        }

        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not found, nerd");
        }

        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void PlayVA(string name)
    {
        Sound s = Array.Find(Vasounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Voice acting not found, nerd");
        }

        else
        {
            VASource.PlayOneShot(s.clip);
        }
    }
}


