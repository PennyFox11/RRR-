using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

//Title: GameObject.SetActive
//Author: Unity Documentation
//Date: 4 May 2026
//Code version: Unity 6000.4
//Availability: https://docs.unity3d.com/ScriptReference/GameObject.SetActive.html

//https://docs.unity3d.com/6000.4/Documentation/ScriptReference/Animator.html


public class PlayerInventory : MonoBehaviour, IPlayerInventory
{
    public static event Action OnKeyCollected;
    public int NumberOfDiamonds = 0;
    private int maxDiamonds = 3;
    private int maxKey = 1;
    public TextMeshProUGUI diamondText;
    public Animator diamondGlowAnimator;
    public int NumberOfKeys;
    public TextMeshProUGUI keyText;
    public Animator keyGlowAnimator;

    

    //[SerializeField] private GameObject Winscreen;


    //void Start()
    //{
        //Winscreen.SetActive(false);
    //}

    void Update()
    {
        diamondText.text = NumberOfDiamonds.ToString() + " /3";

        keyText.text = NumberOfKeys.ToString() + " /1";
    }

    public void DiamondCollected()
    {
        NumberOfDiamonds++;

        diamondGlowAnimator.SetTrigger("collect");

        if (maxDiamonds >= 3)
        {
            Debug.Log("You collected all of them");
        }
    }
    public void KeyCollected()
    {
        NumberOfKeys++;
        keyGlowAnimator.SetTrigger("key");
        if (NumberOfKeys >= maxKey)
        {
            Debug.Log("Congratulations you have passed");
            //Winscreen.SetActive(true);
        }
    }

}





