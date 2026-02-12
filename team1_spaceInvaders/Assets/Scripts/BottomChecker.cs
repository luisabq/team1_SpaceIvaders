using UnityEngine;

public class BottomChecker : MonoBehaviour
{
    public GameOverManager gameOverManager;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            gameOverManager.GameOver();
        }
    }
}
