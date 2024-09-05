using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance { get { return instance; } }

    [Header("게임오버")]
    [SerializeField] private GameObject gameOverImage;

    private bool isGameOver = false;
    public bool IsGameOver { get { return isGameOver; } }

    [Header("재시작 버튼")]
    [SerializeField] private Button restartButton;

    [Header("카메라")]
    [SerializeField] private GameObject gameOverTargetCamera;
    [SerializeField] private GameObject sphereCamera;
    [SerializeField] private GameObject targetCamera;

    [Header("슬라이더")]
    [SerializeField] private Slider directionSlider;
    public Slider DirectionSlider { get { return directionSlider; } }

    [SerializeField] private Slider powerSlider;
    public Slider PowerSlider { get { return powerSlider; } }

    private void Awake()
    {
        if (instance != null)               //이미 존재하면
        {
            Destroy(gameObject);            //두개 이상이니 삭제
            return;
        }
        instance = this;                    //자신을 인스턴스로
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

        // 현재 로드된 이름의 씬을 반환
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
