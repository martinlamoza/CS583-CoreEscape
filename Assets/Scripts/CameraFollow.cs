
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 10f, -8f);
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        // Calculate the desired camera position
        Vector3 desiredPosition = target.position + offset;

        
        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            1f - Mathf.Exp(-smoothSpeed * Time.deltaTime)
        );

        
        transform.LookAt(target);
    }
}
