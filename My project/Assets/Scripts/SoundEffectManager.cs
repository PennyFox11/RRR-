//Title: Add a Sound Effects Manager to Your Game - 2D Platformer Unity #26
//Author: Game Code Library
//Date: 16 February 2024
//Code Version: Unity 2021.3.23f1 LTS

//Title: Add Sound Effects To Your Game! - Top Down Unity 2D #18
//Author: Game Code Library
//Date: 18 February 2025
//Code Version: Unity 2022.3.20f1 LTS

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundEffectManager : MonoBehaviour
{
    private static SoundEffectManager Instance; //makes the sound effect manager callable from any of the present scripts

    private static AudioSource audioSource;
    private static AudioSource randomPitchAudioSource;
    private static AudioSource voiceAudioSource; //npc dialogue text clip
    private static SoundEffectLibrary soundEffectLibrary;
    [SerializeField] private Slider sfxSlider; //to change the volume using UI system

    private void Awake()
    {

        if(Instance = null)
        {
            Instance = this;
            AudioSource[] audioSources = GetComponents<AudioSource>();
            audioSource = audioSources[0];
            randomPitchAudioSource = audioSources[1];
            voiceAudioSource = audioSources[2];
            soundEffectLibrary = GetComponent<SoundEffectLibrary>();
            DontDestroyOnLoad(gameObject); //ensures that sound effect manager is passes through scenes rather than get destroyed upon scene change

        }
    }

    public static void Play(string soundName, bool randomPitch = false) //for audio clips that do not have the random pitch change function
    {
        AudioClip audioClip = soundEffectLibrary.GetRandomClip(soundName);
        if (audioClip != null)
        {
            if (randomPitch) //if an audio does have a random pitch function, this allows the pitch to flucuate randomly
            {
                randomPitchAudioSource.pitch = Random.Range(1f, 1.5f); //range of pitch volume/intensity
                randomPitchAudioSource.PlayOneShot(audioClip);
            }
            else
            {
                audioSource.PlayOneShot(audioClip); //plays sound effect once
            }
        }
    }

    public static void PlayVoice(AudioClip audioClip, float pitch = 1f)
    {
        voiceAudioSource.pitch = pitch;
        voiceAudioSource.PlayOneShot(audioClip);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sfxSlider.onValueChanged.AddListener(delegate { OnValueChanged(); });
    }

    public static void SetVolume(float volume) //setting up volume value changes
    {
        audioSource.volume = volume;
        voiceAudioSource.volume = volume;
    }

    public void OnValueChanged()
    {
        SetVolume(sfxSlider.value); //makes player able to adjust volume with slider UI
    }
}
