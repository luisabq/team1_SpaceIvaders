using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public float speed = 5f;

    public float minX = -5f;
    public float maxX = 5f;

    private float moveInput = 0f;

    void Update()
    {
        moveInput = 0f;

        if (Keyboard.current.aKey.isPressed)
            moveInput -= 1f;

        if (Keyboard.current.dKey.isPressed)
            moveInput += 1f;

        transform.Translate(Vector3.right * moveInput * speed * Time.deltaTime);

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        transform.position = pos;
    }
}