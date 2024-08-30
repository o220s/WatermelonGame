using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    [Header("Ÿ�� ��ü")]
    [SerializeField] private GameObject targetSphere;
    public GameObject TargetSphere { get { return targetSphere; } }

    [Header("���ھ�")]
    [SerializeField] private Text scoreText;
    private int score;

    [SerializeField] private Text gameOverScoreText;
    public Text GameOverScoreText { get { return gameOverScoreText; } }

    [SerializeField] private Text bestScoreText;
    public Text BestScoreText { get { return bestScoreText; } }
    private int bestScore;

    [Header("���ӿ���")]
    [SerializeField] private Image gameOverImage;
    public Image GameOverImage { get { return gameOverImage; } }

    [SerializeField] private Text gameOverText;
    public Text GameOverText { get { return gameOverText; } }

    [SerializeField] private RawImage targetRawImage;
    public RawImage TargetRawImage { get { return targetRawImage; } }

    [Header("����� ��ư")]
    [SerializeField] private Button restartButton;
    public Button RestartButton { get { return restartButton; } }

    [SerializeField] private Text restartButtonText;
    public Text RestartButtonText { get { return restartButtonText; } }

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
        // ���� �ε�� �̸��� ���� ��ȯ
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
        // �� ��ǻ�ͳ��� ������Ʈ���� ���
        PlayerPrefs.SetInt("Best", bestScore);
    }

    private void LoadBestScore()
    {
        // �ְ����� �ҷ����� �ʱⰪ
        bestScore = PlayerPrefs.GetInt("Best", 0);
        bestScoreText.text = "BEST : " + bestScore;
    }
}
