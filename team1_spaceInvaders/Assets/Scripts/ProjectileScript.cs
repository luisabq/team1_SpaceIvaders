using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float projectileSpeed = 10f;

    public float lifetime = 3f;
    private float counter = 0f;

    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindAnyObjectByType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * projectileSpeed * Time.deltaTime);

        counter += Time.deltaTime;
        if (counter > lifetime)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyProjectile"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            scoreManager.AddScore(2);
        }
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            scoreManager.AddScore(5);
        }
    }
}
