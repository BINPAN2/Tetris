using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioClip cursor;
    public AudioClip drop;
    public AudioClip control;
    public AudioClip lineclear;

    private AudioSource audioSource;
    private bool IsMute = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayCursor()
    {
        PlayAudio(cursor);
    }

    public void PlayDrop()
    {
        PlayAudio(drop);
    }

    public void PlayControl()
    {
        PlayAudio(control);
    }

    public void PlayClear()
    {
        PlayAudio(lineclear);
    }

    private void PlayAudio(AudioClip clip)
    {
        if (IsMute == true) return;
        audioSource.clip = clip;
        audioSource.Play();
    }


}
