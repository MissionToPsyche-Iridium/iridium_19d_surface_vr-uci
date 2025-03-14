using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; //for IEnumerator which allows code to run over multiple frames instead of executing everything in a single frame via coroutines.
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance; // Singleton instance to avoid duplicate audio. 

    public AudioClip mainMenuMusic;
    public AudioClip gameSceneMusic;

    private AudioSource audioSource;

    private float fadeDuration = 1.5f; // fade duration for transition from main menu music to game scene music

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); //music will persist across scenes. 
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = true;  // Loop music
        audioSource.playOnAwake = false; //toggle taudio autoplay
        audioSource.volume = 0.5f; // volumn control

        SceneManager.sceneLoaded += OnSceneLoaded;
        PlayMusicForScene(SceneManager.GetActiveScene().name);

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicForScene(scene.name);
    }

    void PlayMusicForScene(string sceneName)
    {
        AudioClip currentAudioClip = null;

        if (sceneName == "MainMenu")
           currentAudioClip = mainMenuMusic;
        else if (sceneName == "PsycheHobaCrater" || sceneName == "PsycheMetalCraterPOC" || sceneName == "PsycheHobaCraterLarge" || sceneName == "PsycheSpacecraftSatellite" || sceneName == "MoonRoverScene")
        {
            StartCoroutine(FadeOutAndChangeMusic(gameSceneMusic));
            return;
        }

        if (currentAudioClip != null && audioSource.clip !=currentAudioClip)
        {
            audioSource.clip =currentAudioClip;
            audioSource.Play();
        }
    }

    IEnumerator FadeOutAndChangeMusic(AudioClip newClip)
    {
        float startVolume = audioSource.volume;

        // Fade out
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeDuration;
            yield return null;
        }

        audioSource.Stop();
        audioSource.clip = newClip;
        audioSource.Play();

        // Fade in
        while (audioSource.volume < startVolume)
        {   
            //Time.deltaTime =The time (in seconds) since the last frame (used for smooth changes)
            audioSource.volume += startVolume * Time.deltaTime / fadeDuration;
            yield return null;
        }
    }

}