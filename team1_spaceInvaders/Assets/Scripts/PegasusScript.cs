using UnityEngine;

public class PegasusScript : MonoBehaviour
{
    public float speed = 10f;

    public float lifetime = 3f;
    private float counter = 0f;

    // Update is called once per frame
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
