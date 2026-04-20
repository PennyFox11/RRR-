//Title: Add a Sound Effects Manager to Your Game - 2D Platformer Unity #26
//Author: Game Code Library
//Date: 16 February 2024
//Code Version: Unity 2021.3.23f1 LTS

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectLibrary : MonoBehaviour
{
    [SerializeField] private SoundEffectGroup[] soundEffectGroups; 
    private Dictionary<string, List<AudioClip>> soundDictionary;
   

    private void Awake() //where audioclips will be stored and retreived from
    { 
        InitializeDictionary();
    }

    private void InitializeDictionary()
    {
        soundDictionary = new Dictionary<string, List<AudioClip>>();
        foreach (SoundEffectGroup soundEffectGroup in soundEffectGroups)
        {
            soundDictionary[soundEffectGroup.name] = soundEffectGroup.audioClips;
        }
        
    }

    public AudioClip GetRandomClip(string name)
    {
        if (soundDictionary.ContainsKey(name)) //ensures that code will still work even if there is only one audio clip available
        {
            List<AudioClip> audioClips = soundDictionary[name];
            if(audioClips.Count > 0)
            {
                return audioClips[UnityEngine.Random.Range(0, audioClips.Count)];
            }
        }
        return null; //if it has not yet returned and there is no more audio
    }

    [System.Serializable] //makes audio viewable in the inspector
    public struct SoundEffectGroup
    {
        public string name;
        public List<AudioClip> audioClips;
    }
}
