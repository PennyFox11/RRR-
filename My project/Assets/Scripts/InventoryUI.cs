using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI diamondText;
    private TextMeshProUGUI inventoryText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        diamondText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateDiamondText(PlayerInventory playerInventory)

    {
        diamondText.text = playerInventory.NumberOfDiamonds.ToString();

    }


}    