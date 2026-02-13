using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

        // PlayMusic(mainMapMusic);

        // if (SceneManager.GetActiveScene().name == "MainMap")
        // {
        //     PlayMusic(mainMapMusic);
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            //MuteMusic();

            PlayMusic(mainMapMusic);
        }

        if (SceneManager.GetActiveScene().name == "BasicMap")
        {
            //MuteMusic();

            PlayMusic(basicMapMusic);
        }
    }

    public AudioClip clickSound;

    public AudioClip mainMapMusic;

    public AudioClip basicMapMusic;
    private AudioSource audioSource;

    public void PlayMusic(AudioClip audio)
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = audio;     // 재생할 음악 지정
        audioSource.loop = true;    // 반복 재생 활성화
        audioSource.playOnAwake = true; // 씬 시작 시 자동 재생
        audioSource.Play();

    }

    public void MuteMusic()
    {
        audioSource.Stop();
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

    public void VolumeUp()
    {
        ChangeVolume(0.1f);
    }

    public void VolumeDown()
    {
        ChangeVolume(-0.1f);
    }
}
