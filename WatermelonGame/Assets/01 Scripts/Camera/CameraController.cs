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
        // 시작점과 끝점 사이를 선형보간하는 함수
        Vector3 newPosition = Vector3.Lerp(transform.position, camPosition, Time.deltaTime * 5f);
        transform.position = newPosition;

        // 타겟을 바라보면서 움직이게끔
        transform.LookAt(targetSphere.transform.position);
    }
}
