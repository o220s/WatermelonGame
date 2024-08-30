using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private GameObject generator;
    private GameObject targetSphere;

    private void Start()
    {
        targetSphere = GameManager.Instance.TargetSphere;
    }

    private void LateUpdate()
    {
        Vector3 camPosition = generator.transform.position + offset;
        Vector3 newPosition = Vector3.Lerp(transform.position, camPosition, Time.deltaTime * 5f);
        transform.position = newPosition;

        // Ÿ���� �ٶ󺸸鼭 �����̰Բ�
        transform.LookAt(targetSphere.transform.position);
    }
}
