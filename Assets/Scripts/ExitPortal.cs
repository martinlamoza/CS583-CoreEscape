
using UnityEngine;

public class ExitPortal : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        // Only allow escape after collecting all energy cores
        if (player != null && gameManager.AllCoresCollected())
        {
            gameManager.WinGame();

            // Stop player movement after winning
            Rigidbody rb = player.GetComponent<Rigidbody>();
            rb.linearVelocity = Vector3.zero;
            player.enabled = false;
        }
    }
}
