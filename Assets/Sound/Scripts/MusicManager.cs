using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager Instance;
    private AudioSource audioSource;
    public AudioClip bgMusic;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            audioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (bgMusic != null) 
        {
            PlayBgMusic(false, bgMusic);
        }
    }

    public void PlayBgMusic(bool shouldReset, AudioClip audioClip = null)
    {
        if (audioClip != null)
        {
            audioSource.clip = audioClip;
        }

        if (audioSource.clip != null)
        {
            if (shouldReset)
            {
                audioSource.Stop();
            }

            audioSource.Play();
        }
    }
}
