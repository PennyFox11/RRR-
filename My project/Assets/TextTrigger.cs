using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//https://docs.unity3d.com/6000.4/Documentation/ScriptReference/MonoBehaviour.StartCoroutine.html 

public class TriggerText : MonoBehaviour
{
    public GameObject textObject;

    private static GameObject currentText; //tracks which text is active

    private bool hasPlayed = false;

    private void Start()
    {
        textObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasPlayed)
        {
            return;
        }
        if (other.CompareTag("Player"))
        {
           hasPlayed = true;

           if (currentText != null && currentText != textObject)
            {
                currentText.SetActive(false);
            }
        
        if (textObject != null) //safety scheck
            {
                        textObject.SetActive(true); //show this text
                        currentText = textObject; //update current text reference
                        StartCoroutine(HideTextAfterDelay()); // start timer to hide it

                        // Destroy(textObject, 3f);
            }

        }
        
        //else
       //{
            //textObject.SetActive(false);
        //}
    }

    private IEnumerator HideTextAfterDelay()
    {
        yield return new WaitForSeconds(3f);

        if (textObject != null) // safety check
        {
            textObject.SetActive(false);
        }
        if (currentText == textObject) //only hide if this is still active text
        {
            currentText = null;
        }
    }

}