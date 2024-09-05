using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance { get { return instance; } }

    [Header("���ӿ���")]
    [SerializeField] private GameObject gameOverImage;

    private bool isGameOver = false;
    public bool IsGameOver { get { return isGameOver; } }

    [Header("����� ��ư")]
    [SerializeField] private Button restartButton;

    [Header("ī�޶�")]
    [SerializeField] private GameObject gameOverTargetCamera;
    [SerializeField] private GameObject sphereCamera;
    [SerializeField] private GameObject targetCamera;

    [Header("�����̴�")]
    [SerializeField] private Slider directionSlider;
    public Slider DirectionSlider { get { return directionSlider; } }

    [SerializeField] private Slider powerSlider;
    public Slider PowerSlider { get { return powerSlider; } }

    private void Awake()
    {
        if (instance != null)               //�̹� �����ϸ�
        {
            Destroy(gameObject);            //�ΰ� �̻��̴� ����
            return;
        }
        instance = this;                    //�ڽ��� �ν��Ͻ���
    }

    private void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
    }

    private void RestartGame()
    {
        Time.timeScale = 1f;
        Destroy(gameObject);
        Destroy(GameManager.Instance.gameObject);
        Destroy(ScoreManager.Instance.gameObject);

        // ���� �ε�� �̸��� ���� ��ȯ
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;

        gameOverImage.SetActive(true);

        gameOverTargetCamera.SetActive(true);
        sphereCamera.SetActive(false);
        targetCamera.SetActive(false);

        GameManager.Instance.UpCountText();
    }
}
