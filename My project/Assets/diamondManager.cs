using UnityEngine;
using TMPro;

public class diamondManager : MonoBehaviour
{
    public int totaldiamonds;
    public TMP_Text diamondText;

    //public Animator glowAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      diamondText.text = "Diamonds: " + totaldiamonds.ToString();
    }

    // Update is called once per frame
    public void Diamonds(int amount)
    {
        totaldiamonds += amount;    
        diamondText.text = amount.ToString(); 
        //glowAnimator.SetTrigger("collect");  
    }
}
