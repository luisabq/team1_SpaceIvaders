using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float projectileSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * projectileSpeed * Time.deltaTime);
    }
}
