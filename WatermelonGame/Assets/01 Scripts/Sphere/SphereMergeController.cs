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
        // 충돌한 오브젝트에서 컴포넌트를 가져옴
        SphereController collisionSphere = collision.gameObject.GetComponent<SphereController>();

        if (collisionSphere != null && collisionSphere.Level == sphereController.Level)
        {
            // 객체 인스턴스 id(고유함)를 비교해서 하나의 오브젝트만 함수 실행
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
        // 첫 번째와 두 번째 사이 위치 계산
        Vector3 newPosition = Vector3.Lerp(firstSphere.transform.position, secondSphere.transform.position, 0.5f);

        // 새로운 오브젝트 생성
        Instantiate(sphereObjects[nextLevel], newPosition, transform.rotation);

        ScoreManager.Instance.GetScore(score);

        GameManager.Instance.UpCount(nextLevel);

        Destroy(firstSphere.gameObject);
        Destroy(secondSphere.gameObject);
    }

    // 타겟 지점 근처에서만 Merge 시키기 위해서
    private bool RangeCheck()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);

        return distance < range;
    }
}

