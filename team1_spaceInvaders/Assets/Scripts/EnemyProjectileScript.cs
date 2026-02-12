using UnityEngine;

public class EnemyProjectileScript : MonoBehaviour
{
    public float projectileSpeed = 10f;

    public float lifetime = 3f;
    private float counter = 0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * projectileSpeed * Time.deltaTime);

        counter += Time.deltaTime;
        if (counter > lifetime)
        {
            Destroy(gameObject);
        }
    }
}
