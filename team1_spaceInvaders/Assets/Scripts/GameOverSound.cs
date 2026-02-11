using UnityEngine;

public class GameOverSound : MonoBehaviour
{
    void Start()
    {
        AudioManager.instance.PlayLoseSound();
    }
}