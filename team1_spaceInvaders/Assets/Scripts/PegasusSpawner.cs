using UnityEngine;

public class PegasusSpawner : MonoBehaviour
{
    public GameObject pegasus;

    [Header("Pegasus has a chance to spawn checkChance/1 \npercent every checkRate seconds")]
    public float checkRate = 5f;
    public float checkChance = 0.5f;
    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= checkRate)
        {
            Debug.Log("Rolling pegasus spawn");

            timer = 0f; // reset timer

            if (Random.value < checkChance)
            {
                Instantiate(pegasus, transform.position, transform.rotation);
            }
        }
    }
}
