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

    // 단순히 구체가 범위밖을 완전히 벗어났을 때
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == target.gameObject)
        {
            isGameOver = true;
            UIManager.Instance.GameOver();
        }
    }

    //// 충돌한 오브젝트중 지정한 범위밖으로 벗어났을 때(범위를 임의로 지정)
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


