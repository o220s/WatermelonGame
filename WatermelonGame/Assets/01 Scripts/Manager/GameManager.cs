using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    [Header("��ü ������")]
    [SerializeField] private GameObject generator;
    public GameObject Generator { get { return generator; } }

    [Header("Ÿ�� ��ü")]
    [SerializeField] private GameObject targetSphere;
    public GameObject TargetSphere { get { return targetSphere; } }

    [Header("��ü ī����")]
    [SerializeField] private Text countText;

    private int[] sphereCounts;

    [Header("��ü ������")]
    [SerializeField] private List<GameObject> spheres;
    public List<GameObject> Spheres { get { return spheres; } }

    private void Awake()
    {
        if (instance != null)               //�̹� �����ϸ�
        {
            Destroy(gameObject);            //�ΰ� �̻��̴� ����
            return;
        }
        instance = this;                    //�ڽ��� �ν��Ͻ���
        DontDestroyOnLoad(gameObject);      //�� �̵��ص� ��������ʰ�
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
