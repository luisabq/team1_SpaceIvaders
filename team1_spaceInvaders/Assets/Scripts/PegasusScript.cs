using UnityEngine;

public class PegasusScript : MonoBehaviour
{
    [Header("Audio")]
    public AudioClip deathClip;

    public float speed = 10f;

    public float lifetime = 3f;
    private float counter = 0f;

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            AudioManager.instance.PlaySFX(deathClip);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        counter += Time.deltaTime;
        if (counter > lifetime)
        {
            Destroy(gameObject);
        }
    }
}
