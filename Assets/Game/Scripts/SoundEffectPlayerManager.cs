using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundEffectPlayerManager : MonoBehaviour
{
    [SerializeField] private AudioSource sfxAudioSource;
    [SerializeField] private AudioSource musicAudioSource;


    public static SoundEffectPlayerManager Instance { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

    }



    public void PlaySfx(AudioClip clip)
    {
        sfxAudioSource.clip = clip;
        sfxAudioSource.Play();
    }


}
