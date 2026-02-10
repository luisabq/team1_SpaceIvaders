using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("projectile"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
