using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform trail;
    
    [SerializeField] private float speedX;
    [SerializeField] private float speedY;
    [SerializeField] private float jumpStrength;
    [SerializeField] private float pushForce;

    private bool _isSoftJumping;
    private bool isPushingUp;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            isPushingUp = true;
        }
        else
        {
            isPushingUp = false;
        }
    }
    
    void FixedUpdate()
    {
        if (_isSoftJumping) speedY += jumpStrength;
        
        trail.position += new Vector3(0, speedY);
        transform.position += new Vector3(speedX,0);
        
        if (isPushingUp)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.up * pushForce);
        }
    }
}