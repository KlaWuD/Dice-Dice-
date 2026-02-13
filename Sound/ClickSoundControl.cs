using UnityEngine;

public class ClickSoundControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        
    }

    public AudioClip clickSound;
    private AudioSource audioSource;

    public void ClickSoundPlay()
    {
        audioSource.PlayOneShot(clickSound);
    }

    public void ChangeVolume(float f)
    {
        audioSource.volume += f;

        if (audioSource.volume < 0.0f)
        {
            audioSource.volume = 0.0f;
        }

        if (audioSource.volume > 1.0f)
        {
            audioSource.volume = 1.0f;
        }
    }

    public void VolumeMute()
    {
        ChangeVolume(-1.0f);
    }

    public void VolumeUp()
    {
        ChangeVolume(0.1f);
    }

    public void VolumeDown()
    {
        ChangeVolume(-0.1f);
    }
}
