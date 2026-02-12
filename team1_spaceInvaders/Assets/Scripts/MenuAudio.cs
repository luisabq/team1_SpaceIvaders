using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip blipSound;

    public void PlayBlip()
    {
        audioSource.PlayOneShot(blipSound);
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}