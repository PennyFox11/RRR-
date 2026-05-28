using UnityEngine;

public class BrightnessManager : MonoBehaviour
{
    public static BrightnessManager Instance;

    [Range(-5f, 5f)]

    public float brightness = 0f;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetBrightness(float value)
    {
        brightness = value;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
