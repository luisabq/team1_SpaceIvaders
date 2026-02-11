using UnityEngine;

public class ShieldTileScript : MonoBehaviour
{
    private int health = 4;

    public Sprite[] damageStates;
    public SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.sprite = damageStates[health - 1];
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile") || other.CompareTag("EnemyProjectile"))
        {
            Destroy(other.gameObject);
            health--;
        }
        else if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
