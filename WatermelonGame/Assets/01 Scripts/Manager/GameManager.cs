using UnityEngine;

public class GameManager : MonoBehaviour
{

    //instance�� static���� �����ؼ� �ٸ� ������Ʈ������ ���� ����
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }


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
}
