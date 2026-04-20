using UnityEngine;
using UnityEngine.UI;


public class PlayerInventory : MonoBehaviour
{

    public int diamondCount;
    public int NumberOfDiamonds = 0;

    private int maxDiamonds = 3;
    public Text diamondText;
    public GameObject door;
    private bool doorDestroyed;

    public void DiamondCollected()
    {
          NumberOfDiamonds++;
      
        if(maxDiamonds >= 3)
        {
            Debug.Log("You collected all of them");
        }
        void Update()
        {
            diamondText.text = ":" .ToString();
            if (diamondCount == 3 && doorDestroyed)
            {
                doorDestroyed = true;
                Destroy(door);
            }
        }
    }  
}


