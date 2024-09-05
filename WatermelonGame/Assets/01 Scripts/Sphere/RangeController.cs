using UnityEngine;

public class RangeController : MonoBehaviour
{
    private bool isGameOver;
  //  private bool isBump = false;
  //  private float range = 6.5f;

    private GameObject target;

    private void Start()
    {
        isGameOver = UIManager.Instance.IsGameOver;
        target = GameManager.Instance.TargetSphere;
    }

    // �ܼ��� ��ü�� �������� ������ ����� ��
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == target.gameObject)
        {
            isGameOver = true;
            UIManager.Instance.GameOver();
        }
    }

    //// �浹�� ������Ʈ�� ������ ���������� ����� ��(������ ���Ƿ� ����)
    // private void Update()
    // {
    //     if (!isGameOver && isBump)
    //     {
    //         OverRange();
    //     }
    // }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject == target.gameObject)
    //     {
    //         isBump = true;
    //     }
    // }

    // private void OverRange()
    // {
    //     float distance = Vector3.Distance(transform.position, target.transform.position);
    //     Debug.Log(distance);
    //     if (distance > range)
    //     {
    //         isGameOver = true;
    //         UIManager.Instance.GameOver();
    //     }
    // }
}


