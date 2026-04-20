using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerInventory : MonoBehaviour, IPlayerInventory
{
    public static event Action OnKeyCollected;
    public int diamondCount;
    public int NumberOfDiamonds = 0;
    private int maxDiamonds = 3;
    public TextMeshProUGUI diamondText;
    public int NumberOfKeys;

    public void DiamondCollected()
    {
        NumberOfDiamonds++;

        if (maxDiamonds >= 3)
        {
            Debug.Log("You collected all of them");
        }

        void Update()
        {
            diamondText.text = " 0:" + NumberOfDiamonds.ToString();


        }
    }

 
    public void KeyCollected()
    {
        NumberOfKeys = 1;
        if (NumberOfKeys == 1)
        {
            Debug.Log("Congratulations you have passed");
            OnKeyCollected?.Invoke();
        }
    }
}

}


