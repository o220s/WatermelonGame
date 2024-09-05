using UnityEngine;

public class SphereController : MonoBehaviour
{

    [SerializeField] private int level;
    public int Level { get { return level; } }

    private float gravityPower = 2f;  // 중력의 세기
    private float gravityRange = 15f;   // 중력장 범위

    private Rigidbody sphereRigidbody;
    private GameObject target;
    private GameObject generator;

    private void Awake()
    {
        sphereRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        target = GameManager.Instance.TargetSphere;
        generator = GameManager.Instance.Generator;
    }

    private void FixedUpdate()
    {
        GravityEffect();
    }

    private void GravityEffect()
    {
        // 타겟과 거리 계산
        float distanceTarget = Vector3.Distance(transform.position, target.transform.position);

        // 타겟이 범위 안에 있을 때만 중력 효과
        if (distanceTarget < gravityRange)
        {
            // 타겟 위치에서 현재 오브젝트의 위치를 빼줌
            Vector3 direction = (target.transform.position - transform.position);
            // rigidbody에게 힘을전달해주는 함수
            sphereRigidbody.AddForce(direction * gravityPower);
            // 항력 조절(반발력 줄이기 위해)
            sphereRigidbody.drag = 1f;
        }
    }

    public void Throw(Vector3 direction)
    {
        sphereRigidbody.AddForce(direction);
    }
}
