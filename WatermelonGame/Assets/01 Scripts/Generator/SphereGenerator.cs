using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SphereGenerator : MonoBehaviour
{
    [SerializeField] private GameObject sphereCamera;

    private int nextSphereIndex;
    private bool isGameOver;
    private float range = 50f;

    private List<GameObject> sphereObjects;
    private GameObject nextSphere;
    private GameObject newSphere;
    private Slider directionSlider;
    private Slider powerSlider;

    private bool isMouseDown = false;

    private void Start()
    {
        isGameOver = UIManager.Instance.IsGameOver;
        sphereObjects = GameManager.Instance.Spheres;
        directionSlider = UIManager.Instance.DirectionSlider;
        powerSlider = UIManager.Instance.PowerSlider;

        // ���� ��ü �̸� ����
        NextSphere();
    }

    private void Update()
    {
        if (!isGameOver)
        {
            // ���콺 ������ �����̴� �� ����
            if (Input.GetMouseButtonDown(0))
            {
                isMouseDown = true;
            }

            // ���콺 ���� �����̴� ���� ���� ������
            if (Input.GetMouseButtonUp(0))
            {
                isMouseDown = false;
                Destroy(nextSphere);
                ThrowSphere();
            }
            // ���콺 ������ ���� �� �Ŀ� �������� ���� ������ ����
            if (isMouseDown)
            {
                MoveSlider();
            }
            DestorySphere();
        }
    }

    private void NextSphere()
    {
        nextSphereIndex = Random.Range(0, 3);
        // �ϴ� ī�޶��� ���� ������Ʈ ����
        nextSphere = Instantiate(sphereObjects[nextSphereIndex], sphereCamera.transform.position, sphereCamera.transform.rotation);
    }

    private void MoveSlider()
    {
        // �Ŀ� �����̴� 0~300���� �Դٰ���
        powerSlider.value = Mathf.PingPong(Time.time * 150f, 300f);

        // ���� �����̴� -45~45���� �Դٰ���
        directionSlider.value = Mathf.PingPong(Time.time * 90f, 90f) - 45f;
    }

    private void ThrowSphere()
    {
        float throwPower = powerSlider.value;
        float throwDirection = directionSlider.value;

        // ������ ���ʹϾ����� ��ȯ�ؼ� ��ü ȸ���� ����
        transform.rotation = Quaternion.Euler(0, throwDirection, 0);

        // ��ü ����
        newSphere = Instantiate(sphereObjects[nextSphereIndex], transform.position, transform.rotation);

        GameManager.Instance.UpCount(nextSphereIndex);

        Vector3 throwVector = transform.rotation * Vector3.forward * throwPower;
        newSphere.GetComponent<SphereController>().Throw(throwVector);

        // ���� ���� ��ü �̸� ����
        NextSphere();
    }

    private void DestorySphere()
    {
        if (newSphere == null) return;
        float distance = Vector3.Distance(transform.position, newSphere.transform.position);

        float sphereSpeed = newSphere.GetComponent<Rigidbody>().velocity.magnitude;

        //Debug.Log(sphereSpeed);
        //if (sphereSpeed > 0f && sphereSpeed < 1f)
        //{
        //    Destroy(newSphere);
        //}

        if (distance > range)
        {
            Destroy(newSphere);
        }
    }
}
