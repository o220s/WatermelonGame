using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject targetSphere;

    private void LateUpdate()
    {
        Vector3 camPosition = target.transform.position;
        Vector3 newPosition = Vector3.Lerp(transform.position, camPosition, Time.deltaTime * 5f);
        transform.position = newPosition;

        transform.LookAt(targetSphere.transform.position);
    }
}
