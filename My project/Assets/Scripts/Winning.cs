//Title: GameObject.SetActive
//Author: Unity Documentation
//Date: 4 May 2026
//Code version: Unity 6000.4
//Availability: https://docs.unity3d.com/ScriptReference/GameObject.SetActive.html

//Title: OnTriggerEnter/OnTriggerExit mechanics
//Author: Unity Discussions
//Date: June 2021 
//Availability: https://discussions.unity.com/t/ontriggerenter-ontriggerexit-mechanics/844873

using UnityEngine;
using UnityEngine.UI;
using System;

public class Winning : MonoBehaviour
{
    [SerializeField] private GameObject winmenu;
    public AudioSource source;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        source = GetComponent<AudioSource>();
        winmenu.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            winmenu.SetActive(true);
            source.Play();
            Time.timeScale = 0f;
        }
    }


}
