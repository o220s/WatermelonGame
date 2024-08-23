using UnityEngine;

public class GeneratorMovement : MonoBehaviour
{
    private float speed = 5f;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized;

        rb.MovePosition(transform.position + movement * speed * Time.fixedDeltaTime);

    }
}
