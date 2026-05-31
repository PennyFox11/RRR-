using UnityEngine;

public class AudioManager : MonoBehaviour

{
    public static AudioManager Instance;

    private AudioSource source;

    private void Awake()
    {
        Instance = this;
        source = GetComponent<AudioSource>();
    }

    public void PlayMusic(AudioClip clip)
    {
        if (source.clip == clip)
            return;

        source.Stop();
        source.clip = clip;
        source.Play();
    }
}
