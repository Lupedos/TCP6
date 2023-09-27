using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundEffectPlayerManager : MonoBehaviour
{
    [SerializeField] private AudioSource clickAudioSource;


    public static SoundEffectPlayerManager Instance { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

    }



    public void PlayCickableSfx(AudioClip clip)
    {
        clickAudioSource.clip = clip;
        clickAudioSource.Play();
    }


}
