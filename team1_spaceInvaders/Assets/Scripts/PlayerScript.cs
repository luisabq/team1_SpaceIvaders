using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    [Header("Movement Parameters")]
    public float speed = 5f;

    public float limit = 5f;

    private float moveInput = 0f;

    [Header("Weapon Parameters")]
    public GameObject projectile;

    public float fireDelay = 1f;

    private float counter;

    public Sprite readySprite;
    public Sprite notReadySprite;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        counter = fireDelay;
        spriteRenderer = GetComponent<SpriteRenderer>();
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

        if (moveInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true;
        }

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -limit, limit);
        transform.position = pos;

        if (Keyboard.current.spaceKey.isPressed && counter >= fireDelay)
        {
            counter = 0f;
            Instantiate(projectile, transform.position, transform.rotation);
        }

        if (counter >= fireDelay)
        {
            spriteRenderer.sprite = readySprite;
        }
        else
        {
            spriteRenderer.sprite = notReadySprite;
        }
    }
}