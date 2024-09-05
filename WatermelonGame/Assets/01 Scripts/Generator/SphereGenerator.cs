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

        // 시작 구체 미리 설정
        NextSphere();
    }

    private void Update()
    {
        if (!isGameOver)
        {
            // 마우스 누르면 슬라이더 값 조절
            if (Input.GetMouseButtonDown(0))
            {
                isMouseDown = true;
            }

            // 마우스 떼면 슬라이더 값에 따라 던지기
            if (Input.GetMouseButtonUp(0))
            {
                isMouseDown = false;
                Destroy(nextSphere);
                ThrowSphere();
            }
            // 마우스 누르고 있을 때 파워 게이지와 방향 게이지 증가
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
        // 하단 카메라의 다음 오브젝트 생성
        nextSphere = Instantiate(sphereObjects[nextSphereIndex], sphereCamera.transform.position, sphereCamera.transform.rotation);
    }

    private void MoveSlider()
    {
        // 파워 슬라이더 0~300까지 왔다갔다
        powerSlider.value = Mathf.PingPong(Time.time * 150f, 300f);

        // 방향 슬라이더 -45~45까지 왔다갔다
        directionSlider.value = Mathf.PingPong(Time.time * 90f, 90f) - 45f;
    }

    private void ThrowSphere()
    {
        float throwPower = powerSlider.value;
        float throwDirection = directionSlider.value;

        // 방향을 쿼터니언으로 변환해서 구체 회전에 대입
        transform.rotation = Quaternion.Euler(0, throwDirection, 0);

        // 구체 생성
        newSphere = Instantiate(sphereObjects[nextSphereIndex], transform.position, transform.rotation);

        GameManager.Instance.UpCount(nextSphereIndex);

        Vector3 throwVector = transform.rotation * Vector3.forward * throwPower;
        newSphere.GetComponent<SphereController>().Throw(throwVector);

        // 다음 생성 구체 미리 설정
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
