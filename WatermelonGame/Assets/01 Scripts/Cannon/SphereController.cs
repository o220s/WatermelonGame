using UnityEngine;

public class SphereController : MonoBehaviour
{
    private Rigidbody sphereRigidbody;

    private void Awake()
    {
        sphereRigidbody = GetComponent<Rigidbody>();
    }
  
    public void Throw(Vector3 sphereSpeed)
    {
        sphereRigidbody.AddForce(sphereSpeed);
    }
}
