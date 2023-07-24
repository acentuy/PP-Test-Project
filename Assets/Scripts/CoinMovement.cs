using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    [SerializeField] private float force = 2;

    private bool isCloseToSnake = false;
    private Transform snakeTransform;

    private void FixedUpdate()
    {
        if (isCloseToSnake)
        {
            Vector3 direction = (snakeTransform.position - transform.position).normalized;
            float step = force * Time.deltaTime;

            transform.Translate(direction * step);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isCloseToSnake = true;
            snakeTransform = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isCloseToSnake = false;
        }
    }
}
