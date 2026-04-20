using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerInventory : MonoBehaviour, IPlayerInventory
{
    public int NumberOfDiamonds = 0;
    private int maxDiamonds = 3;
    private int maxKey = 1;
    public TextMeshProUGUI diamondText;
    public int NumberOfKeys;
    public TextMeshProUGUI keyText;

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
        if (maxKey >= 1)
        {
            Debug.Log("Congratulations you have passed");
        }
    }

}





