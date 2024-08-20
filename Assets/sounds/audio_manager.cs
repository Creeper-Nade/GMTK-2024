using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_manager : MonoBehaviour
{
    [SerializeField] private AudioSource sfx;
    public AudioClip shriek;
    public AudioClip eee;
    void Start()
    {
        
    }

    public void play_sfx(AudioClip clip)
    {
        sfx.PlayOneShot(clip);
    }
}
