using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    [Header("구체 생성기")]
    [SerializeField] private GameObject generator;
    public GameObject Generator { get { return generator; } }

    [Header("타겟 구체")]
    [SerializeField] private GameObject targetSphere;
    public GameObject TargetSphere { get { return targetSphere; } }

    [Header("구체 카운터")]
    [SerializeField] private Text countText;

    private int[] sphereCounts;

    [Header("구체 데이터")]
    [SerializeField] private List<GameObject> spheres;
    public List<GameObject> Spheres { get { return spheres; } }

    private void Awake()
    {
        if (instance != null)               //이미 존재하면
        {
            Destroy(gameObject);            //두개 이상이니 삭제
            return;
        }
        instance = this;                    //자신을 인스턴스로
        DontDestroyOnLoad(gameObject);      //씬 이동해도 사라지지않게
    }

    private void Start()
    {
        sphereCounts = new int[spheres.Count];
    }

    public void UpCount(int sphereIndex)
    {
        sphereCounts[sphereIndex]++;
    }

    public void UpCountText()
    {
        countText.text = "";
        for (int index = 0; index < sphereCounts.Length; index++)
        {
            countText.text += "sphere" + index + "  x " + sphereCounts[index] + "ea" + "\n";
        }
    }
}
