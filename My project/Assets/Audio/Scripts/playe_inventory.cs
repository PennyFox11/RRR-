using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class PlayerInventory : MonoBehaviour, IPlayerInventory
{
    public static event Action OnKeyCollected;
    public int NumberOfDiamonds = 0;
    private int maxDiamonds = 3;
    private int maxKey = 1;
    public TextMeshProUGUI diamondText;
    public int NumberOfKeys;
    public TextMeshProUGUI keyText;

    [SerializeField] private GameObject Winscreen;

    void Start()
    {
        Winscreen.SetActive(false);
    }

    void Update()
    {
        diamondText.text = NumberOfDiamonds.ToString() + " /3";

        keyText.text = NumberOfKeys.ToString() + " /1";
    }

    public void DiamondCollected()
    {
        NumberOfDiamonds++;

        if (maxDiamonds >= 3)
        {
            Debug.Log("You collected all of them");
        }
    }
    public void KeyCollected()
    {
        NumberOfKeys++;
        if (NumberOfKeys >= maxKey)
        {
            Debug.Log("Congratulations you have passed");
            Winscreen.SetActive(true);
        }
    }

}





