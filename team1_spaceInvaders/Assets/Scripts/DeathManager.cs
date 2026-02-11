using System.Collections;
using UnityEngine;
using TMPro;

public class DeathManager : MonoBehaviour
{
    public int lives = 3;

    public GameObject enemies;
    public PlayerScript playerScript;
    public SpriteRenderer spriteRenderer;
    public GameOverManager gameOverManager;

    private Vector3 playerPos;
    private Vector3 enemyPos;

    public Sprite[] deathFrames;
    public float frameTime = 0.25f;

    public TextMeshProUGUI healthText;

    [Header("Audio")]
    public AudioClip deathSound;
    private AudioSource audioSource;

    void Start()
    {
        playerPos = transform.position;
        enemyPos = enemies.transform.position;

        healthText.text = ("Lives: " + lives);

        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyProjectile") || collision.CompareTag("Enemy"))
        {
            GameObject[] projectiles = GameObject.FindGameObjectsWithTag("EnemyProjectile");

            foreach (GameObject projectile in projectiles)
            {
                Destroy(projectile);
            }

            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        lives--;
        audioSource.PlayOneShot(deathSound);
        Debug.Log("Life lost)");
        healthText.text = ("Lives: " + lives);

        playerScript.enabled = false;

        Time.timeScale = 0f;

        for (int i = 0; i < deathFrames.Length; i++)
        {
            spriteRenderer.sprite = deathFrames[i];
            yield return new WaitForSecondsRealtime(frameTime);
        }

        if (lives > 0)
        {
            transform.position = playerPos;
            enemies.transform.position = enemyPos;
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Pegasus"))
            {
                Destroy(obj);
            }
        }
        else
        {
            Debug.Log("Game Over");

            AudioManager.instance.StopMusic();
        }

        Time.timeScale = 1f;
        playerScript.enabled = true;

        if (lives <= 0)
        {
            gameOverManager.GameOver();
        }
    }
}
