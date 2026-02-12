using UnityEngine;

public class WinSound : MonoBehaviour
{
    void Start()
    {
        AudioManager.instance.PlayVictorySound();
    }
}