
using UnityEngine;

public class MovingHazard : MonoBehaviour
{
    public float moveDistance = 5f;
    public float moveSpeed = 1.5f;

    private Vector3 startPosition;
    private Rigidbody rb;

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Move the obstacle back and forth
        float offset = Mathf.Sin(Time.fixedTime * moveSpeed)
            * moveDistance;

        rb.MovePosition(startPosition + Vector3.right * offset);
    }

    void OnTriggerEnter(Collider other)
    {
        // Respawn the player when hit by the obstacle
        PlayerController player = other.GetComponent<PlayerController>();

        if (player != null)
        {
            player.Respawn();
        }
    }
}
