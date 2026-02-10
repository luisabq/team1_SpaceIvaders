using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    [Header("Movement Parameters")]
    public float speed = 5f;

    public float minX = -5f;
    public float maxX = 5f;

    private float moveInput = 0f;

    [Header("Weapon Parameters")]
    public GameObject projectile;

    public float fireDelay = 1f;

    private float counter;

    private void Start()
    {
        counter = fireDelay;
    }

    void Update()
    {
        moveInput = 0f;
        counter += Time.deltaTime;

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            moveInput -= 1f;

        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            moveInput += 1f;

        transform.Translate(Vector3.right * moveInput * speed * Time.deltaTime);

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        transform.position = pos;

        if (Keyboard.current.spaceKey.isPressed && counter >= fireDelay)
        {
            counter = 0f;
            Instantiate(projectile, transform.position, transform.rotation);
        }
    }
}