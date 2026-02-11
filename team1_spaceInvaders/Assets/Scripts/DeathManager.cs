using System.Collections;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    public int lives = 3;

    public GameObject enemies;
    public PlayerScript playerScript;
    public SpriteRenderer spriteRenderer;

    private Vector3 playerPos;
    private Vector3 enemyPos;

    public Sprite[] deathFrames;
    public float frameTime = 0.15f;

    private bool dead = false;
        void Start()
    {
        playerPos = transform.position;
        enemyPos = enemies.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyProjectile") && !dead)
        {
            dead = true;

            GameObject[] projectiles = GameObject.FindGameObjectsWithTag("EnemyProjectile");

            foreach (GameObject proj in projectiles)
            {
                Destroy(proj);
            }

            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        dead = true;
        lives--;
        Debug.Log("Life lost)");

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
        }
        else
        {
            Debug.Log("Game Over");
        }

        Time.timeScale = 1f;
        playerScript.enabled = true;
        dead = false;
    }
}
