using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangeController : MonoBehaviour
{
    private float range = 6.5f;
    private bool isGameOver = false;
    public bool IsGameOver { get { return isGameOver; } }

    private List<GameObject> newObjectList = new List<GameObject>();

    private Image gameOverImage;
    private Text gameOverText;
    private RawImage targetRawImage;
    private Text gameOverScoreText;
    private Text bestScoreText;
    private Button restartButton;
    private Text restartButtonText;

    private void Start()
    {
        gameOverImage = GameManager.Instance.GameOverImage;
        gameOverText = GameManager.Instance.GameOverText;
        targetRawImage = GameManager.Instance.TargetRawImage;
        gameOverScoreText = GameManager.Instance.GameOverScoreText;
        bestScoreText = GameManager.Instance.BestScoreText;
        restartButton = GameManager.Instance.RestartButton;
        restartButtonText = GameManager.Instance.RestartButtonText;
    }
    private void Update()
    {
        if (!isGameOver)
        {
            RangeOver();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // ���ο� �ִ� ������Ʈ�� ����Ʈ�� �߰�
        newObjectList.Add(other.gameObject);
    }

    private void RangeOver()
    {
        for (int i = 0; i < newObjectList.Count; i++)
        {
            // Ÿ�� ��ü�� �浹�� ������Ʈ�� �Ÿ��� ���
            float distance = Vector3.Distance(transform.position, newObjectList[i].transform.position);
            // ������ �Ѿ ��� ��������
            if (distance > range)
            {
                isGameOver = true;
                GameOver();
                break;
            }
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0f;
        gameOverImage.enabled = true;
        gameOverText.enabled = true;
        targetRawImage.enabled = true;
        gameOverScoreText.enabled = true;
        bestScoreText.enabled = true;
        restartButton.enabled = true;
        restartButton.image.enabled = true;
        restartButtonText.enabled = true;
    }
}
