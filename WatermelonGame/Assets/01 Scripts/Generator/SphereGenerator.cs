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
        // ���� ��ü �̸� ����
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
        // �ϴ� ī�޶��� ���� ������Ʈ ����
        nextSphere = Instantiate(sphereObjects[nextSphereIndex], sphereCamera.transform.position, sphereCamera.transform.rotation);
    }

    private void ThrowSphere()
    {
        // ��ü ����
        GameObject newSphere = Instantiate(sphereObjects[nextSphereIndex], transform.position, transform.rotation);

        // ray�� ���콺������ �޾ƿ� ������ ����
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 sphereDirection = ray.direction * throwPower;
        // ������ ������Ʈ�� ������Ʈ�� �޼ҵ� ����
        newSphere.GetComponent<SphereController>().Throw(sphereDirection);

        // ���� ���� ��ü �̸� ����
        NextSphere();
    }
}

