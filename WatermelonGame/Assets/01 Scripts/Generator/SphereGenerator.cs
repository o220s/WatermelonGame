using System.Collections.Generic;
using UnityEngine;

public class SphereGenerator : MonoBehaviour
{
    [SerializeField] private GameObject sphereCamera;

    private int nextSphereIndex;
    private float throwPower = 300f;

    private List<GameObject> sphereObjects;
    private GameObject nextSphere;
    private GameObject target;

    private void Start()
    {
        sphereObjects = GameManager.Instance.Spheres;
        target = GameManager.Instance.TargetSphere;
        // 시작 구체 미리 설정
        NextSphere();
    }

    private void Update()
    {
        if (!target.GetComponent<RangeController>().IsGameOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(nextSphere);
                ThrowSphere();
            }
        }
    }

    private void NextSphere()
    {
        nextSphereIndex = Random.Range(0, 3);
        // 하단 카메라의 다음 오브젝트 생성
        nextSphere = Instantiate(sphereObjects[nextSphereIndex], sphereCamera.transform.position, sphereCamera.transform.rotation);
    }

    private void ThrowSphere()
    {
        // 구체 생성
        GameObject newSphere = Instantiate(sphereObjects[nextSphereIndex], transform.position, transform.rotation);

        // ray로 마우스방향을 받아와 변수에 저장
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 sphereDirection = ray.direction * throwPower;
        // 생성된 오브젝트의 컴포넌트에 메소드 실행
        newSphere.GetComponent<SphereController>().Throw(sphereDirection);

        // 다음 생성 구체 미리 설정
        NextSphere();
    }
}

