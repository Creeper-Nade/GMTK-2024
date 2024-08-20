using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_manager : MonoBehaviour
{
    [SerializeField] private AudioSource sfx;
    [SerializeField] private AudioSource ambient;
    public AudioClip shriek;
    public AudioClip background;
    public AudioClip whitenoise;

    public AudioClip another_noise;
    public AudioClip quiet;
    public AudioClip eee;
    void Start()
    {
        ambient.clip=background;
        ambient.Play();
    }

    public void play_sfx(AudioClip clip)
    {
        sfx.PlayOneShot(clip);
    }
}
