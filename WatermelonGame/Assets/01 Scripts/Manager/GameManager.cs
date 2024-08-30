using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    [Header("타겟 구체")]
    [SerializeField] private GameObject targetSphere;
    public GameObject TargetSphere { get { return targetSphere; } }

    [Header("스코어")]
    [SerializeField] private Text scoreText;
    private int score;

    [SerializeField] private Text gameOverScoreText;
    public Text GameOverScoreText { get { return gameOverScoreText; } }

    [SerializeField] private Text bestScoreText;
    public Text BestScoreText { get { return bestScoreText; } }
    private int bestScore;

    [Header("게임오버")]
    [SerializeField] private Image gameOverImage;
    public Image GameOverImage { get { return gameOverImage; } }

    [SerializeField] private Text gameOverText;
    public Text GameOverText { get { return gameOverText; } }

    [SerializeField] private RawImage targetRawImage;
    public RawImage TargetRawImage { get { return targetRawImage; } }

    [Header("재시작 버튼")]
    [SerializeField] private Button restartButton;
    public Button RestartButton { get { return restartButton; } }

    [SerializeField] private Text restartButtonText;
    public Text RestartButtonText { get { return restartButtonText; } }

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
        LoadBestScore();
    }

    private void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
    }

    private void RestartGame()
    {
        Time.timeScale = 1f;
        Destroy(gameObject);
        // 현재 로드된 이름의 씬을 반환
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Score(int gameScore)
    {
        score += gameScore;
        scoreText.text = "SCORE : " + score;
        gameOverScoreText.text = "SCORE : " + score;

        if (score > bestScore)
        {
            bestScore = score;
            bestScoreText.text = "BEST : " + bestScore;
            SaveBestScore();
        }
    }

    private void SaveBestScore()
    {
        // 현 컴퓨터내에 레지스트리에 등록
        PlayerPrefs.SetInt("Best", bestScore);
    }

    private void LoadBestScore()
    {
        // 최고점수 불러오기 초기값
        bestScore = PlayerPrefs.GetInt("Best", 0);
        bestScoreText.text = "BEST : " + bestScore;
    }
}
