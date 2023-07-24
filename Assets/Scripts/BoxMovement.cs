using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    [SerializeField] private float minDistance = 1f;
    
    [SerializeField] private float maxDistance = 3f;
    
    [SerializeField] private float minTime = 1f;
    [SerializeField] private float maxTime = 3f;
    
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool movingUp;
    private bool movementInProgress;

    private float currentTime;
    private float elapsedTime;

    private void OnEnable()
    {
        StartMovement();
    }

    private void OnDisable()
    {
        StopMovement();
    }

    private void StartMovement()
    {
        movementInProgress = true;
        movingUp = true;
        startPosition = transform.position;
        SetNewTargetPosition();
    }

    private void StopMovement()
    {
        movementInProgress = false;
    }

    private void Update()
    {
        if (!movementInProgress)
            return;

        HandleMovement();
    }

    private void HandleMovement()
    {
        elapsedTime += Time.deltaTime;

        float t = Mathf.Clamp01(elapsedTime / currentTime);
        Vector3 currentPos = Vector3.Lerp(startPosition, targetPosition, t);
        transform.position = currentPos;

        if (elapsedTime >= currentTime)
        {
            movingUp = !movingUp;
            startPosition = targetPosition;
            SetNewTargetPosition();
        }
    }

    private void SetNewTargetPosition()
    {
        float currentDistance = Random.Range(minDistance, maxDistance);
        currentTime = Random.Range(minTime, maxTime);
        elapsedTime = 0f;
        Vector3 direction = movingUp ? Vector3.up : Vector3.down;
        targetPosition = startPosition + direction * currentDistance;
    }
}