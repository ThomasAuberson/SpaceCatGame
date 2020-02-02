using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGM : MonoBehaviour
{
    private static BGM instance = null;		// maintain ONE instance of the script/parent object
    private AudioSource audioSource;

    public AudioClip bgmIntro;

    public static BGM GetInstance()
    {
        return instance;
    }

    // called zero
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
    }

    // called first
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainScene" || scene.name == "RepairMinigameScene")
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(bgmIntro);
                audioSource.PlayScheduled(AudioSettings.dspTime + bgmIntro.length);
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    // called when the game is terminated
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
