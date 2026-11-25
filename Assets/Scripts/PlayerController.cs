
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6f;

    private Rigidbody rb;
    private Vector3 movement;
    private Vector3 spawnPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawnPosition = transform.position;
    }

    void Update()
    {
        Keyboard keyboard = Keyboard.current;

        if (keyboard == null)
        {
            movement = Vector3.zero;
            return;
        }

        float x = 0f;
        float z = 0f;

        // Read player movement input
        if (keyboard.wKey.isPressed) z += 1f;
        if (keyboard.sKey.isPressed) z -= 1f;
        if (keyboard.aKey.isPressed) x -= 1f;
        if (keyboard.dKey.isPressed) x += 1f;

        movement = new Vector3(x, 0f, z).normalized;
    }

    void FixedUpdate()
    {
        // Move the player while preserving gravity
        rb.linearVelocity = new Vector3(
            movement.x * moveSpeed,
            rb.linearVelocity.y,
            movement.z * moveSpeed
        );
    }

    // Return the player to the starting position
    public void Respawn()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.position = spawnPosition;
        movement = Vector3.zero;
    }
}
