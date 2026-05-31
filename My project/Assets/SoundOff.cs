using UnityEngine;


public class SoundOff : MonoBehaviour
{
    AudioSource source;
    Collider2D soundTrigger;

    bool IsPlayerInTrigger;
   
    void Awake()
    {
        source = GetComponent<AudioSource>(); //get the audio source
        soundTrigger = GetComponent<Collider2D>(); //get the collider

    }
    void OnTriggerExit2D(Collider2D collider) //if player exits, stop playing the audio
    {
        if (collider.CompareTag("Player"))
        {
            IsPlayerInTrigger = true;
            source.Play();   
        }
        else
        {
            IsPlayerInTrigger = false;
            source.Stop();
        }
       
    }

}