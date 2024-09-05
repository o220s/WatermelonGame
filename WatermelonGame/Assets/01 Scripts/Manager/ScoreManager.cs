using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;
    public static ScoreManager Instance { get { return instance; } }

    [Header("���ھ�")]
    [SerializeField] private Text scoreText;
    [SerializeField] private Text gameOverScoreText;
    [SerializeField] private Text bestScoreText;

    private int score;
    private int bestScore;

    private void Awake()
    {
        if (instance != null)               //�̹� �����ϸ�
        {
            Destroy(gameObject);            //�ΰ� �̻��̴� ����
            return;
        }
        instance = this;                    //�ڽ��� �ν��Ͻ���
        LoadBestScore();
    }

    public void GetScore(int gameScore)
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
