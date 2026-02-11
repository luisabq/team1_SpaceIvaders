using System;
using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float speed = 2f;

    public float dropTime = 0.5f;

    public float boundary = 3f;

    private int direction = 1;
    private bool dropping = false;

    // Update is called once per frame
    void Update()
    {
        if (dropping)
        {
            return;
        }

        if (direction == 1 && transform.position.x >= boundary || direction == -1 && transform.position.x <= -boundary)
        {
            direction *= -1;
            StartCoroutine(Drop());
        }
        else
        {
            transform.Translate(Vector3.right * direction * speed * Time.deltaTime);
        }
    }

    IEnumerator Drop()
    {
        dropping = true;

        float counter = 0f;

        while (counter <= dropTime)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            counter += Time.deltaTime;
            yield return null;
        }

        dropping = false;
    }
}
