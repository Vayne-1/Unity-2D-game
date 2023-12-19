using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    public AudioClip background1; 
    public AudioClip background234;
    public AudioClip background5;
    public AudioClip coin;
    public AudioClip checkpoint;
    public AudioClip death;
    public AudioClip teleport;
    public AudioClip shoot1;
    public AudioClip shoot2;
    public AudioClip jump;
    public AudioClip boss_attack;
    public AudioClip boss_enrage;
    public AudioClip boss_death;
    private void Start()
    {
        musicSource.clip = background1;
        musicSource.Play();

    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}

