using UnityEngine;

public class GeneratorMovement : MonoBehaviour
{
    private float speed = 15f;
    private Rigidbody generatorRigidbody;

    private void Awake()
    {
        generatorRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");     // 수평
        float vertical = Input.GetAxis("Vertical");         // 수직

        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized;

        generatorRigidbody.MovePosition(transform.position + movement * speed * Time.fixedDeltaTime);
    }
}
