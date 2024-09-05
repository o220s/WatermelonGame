using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;
    public static ScoreManager Instance { get { return instance; } }

    [Header("스코어")]
    [SerializeField] private Text scoreText;
    [SerializeField] private Text gameOverScoreText;
    [SerializeField] private Text bestScoreText;

    private int score;
    private int bestScore;

    private void Awake()
    {
        if (instance != null)               //이미 존재하면
        {
            Destroy(gameObject);            //두개 이상이니 삭제
            return;
        }
        instance = this;                    //자신을 인스턴스로
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
