using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject projectile;

    private float rayDistance = 10f;
    public LayerMask enemyLayer;

    public float enemyFireRate = 0.2f;
    private float timer = 0f;

    private void Update()
    {
        if (IsLowest())
        {
            timer += Time.deltaTime;

            if (timer >= 1f)
            {
                timer = 0f; // reset timer

                if (Random.value < enemyFireRate)
                {
                    Instantiate(projectile, transform.position, transform.rotation);
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
    public bool IsLowest()
    {
        BoxCollider2D col = GetComponent<BoxCollider2D>();

        Vector2 rayStart = new Vector2(transform.position.x, transform.position.y - col.bounds.extents.y - 0.05f);

        RaycastHit2D hit = Physics2D.Raycast(rayStart, Vector2.down, rayDistance, enemyLayer);

        if (hit.collider != null)
        {
            return false;
        }

        return true;
    }
}
