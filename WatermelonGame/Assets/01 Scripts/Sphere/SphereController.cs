using UnityEngine;

public class SphereController : MonoBehaviour
{

    [SerializeField] private int level;
    public int Level { get { return level; } }

    private float gravityPower = 2f;  // �߷��� ����
    private float gravityRange = 15f;   // �߷��� ����

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
        // Ÿ�ٰ� �Ÿ� ���
        float distanceTarget = Vector3.Distance(transform.position, target.transform.position);

        // Ÿ���� ���� �ȿ� ���� ���� �߷� ȿ��
        if (distanceTarget < gravityRange)
        {
            // Ÿ�� ��ġ���� ���� ������Ʈ�� ��ġ�� ����
            Vector3 direction = (target.transform.position - transform.position);
            // rigidbody���� �����������ִ� �Լ�
            sphereRigidbody.AddForce(direction * gravityPower);
            // �׷� ����(�ݹ߷� ���̱� ����)
            sphereRigidbody.drag = 1f;
        }
    }

    public void Throw(Vector3 direction)
    {
        sphereRigidbody.AddForce(direction);
    }
}
