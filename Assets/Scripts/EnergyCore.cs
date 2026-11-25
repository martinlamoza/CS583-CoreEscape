
using UnityEngine;

public class EnergyCore : MonoBehaviour
{
    public float rotationSpeed = 90f;
    public GameManager gameManager;

    private bool collected = false;

    void Update()
    {
        // Rotate the energy core continuously
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        // Collect the core when the player touches it
        if (!collected && other.GetComponent<PlayerController>() != null)
        {
            collected = true;
            gameManager.CollectCore();
            Destroy(gameObject);
        }
    }
}
