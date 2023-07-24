using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float horizontalDistance = -5f;

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 desiredPosition = new Vector3(targetPosition.x - horizontalDistance, transform.position.y, transform.position.z); 
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}