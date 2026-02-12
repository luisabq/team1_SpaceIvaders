using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource musicSource;
    public AudioSource sfxSource;

    public AudioClip backgroundMusic;
    public AudioClip loseClip;

    public AudioClip victoryClip;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene Loaded: " + scene.name);

        if (scene.name == "Level 1" || scene.name == "Level 2")
        {
            Debug.Log("Playing music");
            if (!musicSource.isPlaying)
            {
                musicSource.Play();
            }
        }
        else
        {
            Debug.Log("Stopping music");
            musicSource.Stop();
        }
    }
    public void PlayVictorySound()
    {
        sfxSource.PlayOneShot(victoryClip);
    }
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        
        if (currentScene.name == "Level1" || currentScene.name == "Level2")
        {
            musicSource.Play();
        }
    }
    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void PlayLoseSound()
    {
        sfxSource.PlayOneShot(loseClip);
    }
}
