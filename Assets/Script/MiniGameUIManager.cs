using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniGameUIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI returnMainScenes;
    public Button returnButton;
    public Button restartButton;  // ����� ��ư �߰�
    private int currentScore = 0;

    public void Start()
    {
        if (restartText == null)
        {
            Debug.LogError("restartText is null");
        }

        if (scoreText == null)
        {
            Debug.LogError("scoreText is null");
            return;
        }

        if (returnMainScenes == null)
        {
            Debug.LogError("returnMainScenes is null");
        }

        if (returnButton == null)
        {
            Debug.LogError("returnButton is null");
        }
        else
        {
            returnButton.onClick.AddListener(ReturnToMainScene);
        }

        if (restartButton == null)
        {
            Debug.LogError("restartButton is null");
        }
        else
        {
            restartButton.onClick.AddListener(RestartGame);
        }

        restartText.gameObject.SetActive(false);
        returnMainScenes.gameObject.SetActive(false); // ó������ ���� �� ��ư�� ��Ȱ��ȭ
        LoadScore(); // ���� ���۵� �� ����� ������ �ҷ���
    }

    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);
        returnMainScenes.gameObject.SetActive(true);  // ����� ��ư�� ���� �� ��ư�� �� �� Ȱ��ȭ
        restartButton.gameObject.SetActive(true); // ����� ��ư Ȱ��ȭ
        returnButton.gameObject.SetActive(true); // ���� �� ��ư Ȱ��ȭ
    }

    public void UpdateScore(int score)
    {
        currentScore = score;
        scoreText.text = currentScore.ToString();
        PlayerPrefs.SetInt("MiniGameScore", currentScore); // ���� ����
        PlayerPrefs.Save(); // ��� ����
    }

    public void ReturnToMainScene()
    {
        PlayerPrefs.SetInt("MiniGameScore", currentScore); // �� ���� �� ���� ����
        PlayerPrefs.Save();
        SceneManager.LoadScene("MiniGameMain");
    }

    public void RestartGame()
    {
        // ������� ������ ���� ���¸� �ʱ�ȭ
        currentScore = 0;
        scoreText.text = currentScore.ToString(); // ���� �ʱ�ȭ
        PlayerPrefs.SetInt("MiniGameScore", currentScore); // ���� �ʱ�ȭ �� ����
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ���� ���� �ٽ� �ε�
    }

    private void LoadScore()
    {
        if (PlayerPrefs.HasKey("MiniGameScore"))
        {
            currentScore = PlayerPrefs.GetInt("MiniGameScore");
            scoreText.text = currentScore.ToString();
        }
    }
}