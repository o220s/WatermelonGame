using System.Collections.Generic;
using UnityEngine;

public class SphereMergeController : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private float range = 15f;

    private GameObject target;
    private List<GameObject> sphereObjects;
    private SphereController sphereController;

    private void Awake()
    {
        sphereController = GetComponent<SphereController>();
    }

    private void Start()
    {
        sphereObjects = GameManager.Instance.Spheres;
        target = GameManager.Instance.TargetSphere;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �浹�� ������Ʈ���� ������Ʈ�� ������
        SphereController collisionSphere = collision.gameObject.GetComponent<SphereController>();

        if (collisionSphere != null && collisionSphere.Level == sphereController.Level)
        {
            // ��ü �ν��Ͻ� id(������)�� ���ؼ� �ϳ��� ������Ʈ�� �Լ� ����
            if (gameObject.GetInstanceID() < collision.gameObject.GetInstanceID())
            {
                int nextLevel = collisionSphere.Level + 1;

                if (RangeCheck() && nextLevel < sphereObjects.Count)
                {
                    Merge(nextLevel, gameObject, collision.gameObject);
                }
            }
        }
    }

    private void Merge(int nextLevel, GameObject firstSphere, GameObject secondSphere)
    {
        // ù ��°�� �� ��° ���� ��ġ ���
        Vector3 newPosition = Vector3.Lerp(firstSphere.transform.position, secondSphere.transform.position, 0.5f);

        // ���ο� ������Ʈ ����
        Instantiate(sphereObjects[nextLevel], newPosition, transform.rotation);

        ScoreManager.Instance.GetScore(score);

        GameManager.Instance.UpCount(nextLevel);

        Destroy(firstSphere.gameObject);
        Destroy(secondSphere.gameObject);
    }

    // Ÿ�� ���� ��ó������ Merge ��Ű�� ���ؼ�
    private bool RangeCheck()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);

        return distance < range;
    }
}

