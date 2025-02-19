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
    public Button restartButton;  // 재시작 버튼 추가
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
        returnMainScenes.gameObject.SetActive(false); // 처음에는 메인 씬 버튼도 비활성화
        LoadScore(); // 씬이 시작될 때 저장된 점수를 불러옴
    }

    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);
        returnMainScenes.gameObject.SetActive(true);  // 재시작 버튼과 메인 씬 버튼을 둘 다 활성화
        restartButton.gameObject.SetActive(true); // 재시작 버튼 활성화
        returnButton.gameObject.SetActive(true); // 메인 씬 버튼 활성화
    }

    public void UpdateScore(int score)
    {
        currentScore = score;
        scoreText.text = currentScore.ToString();
        PlayerPrefs.SetInt("MiniGameScore", currentScore); // 점수 저장
        PlayerPrefs.Save(); // 즉시 저장
    }

    public void ReturnToMainScene()
    {
        PlayerPrefs.SetInt("MiniGameScore", currentScore); // 씬 변경 전 점수 저장
        PlayerPrefs.Save();
        SceneManager.LoadScene("MiniGameMain");
    }

    public void RestartGame()
    {
        // 재시작을 누르면 게임 상태를 초기화
        currentScore = 0;
        scoreText.text = currentScore.ToString(); // 점수 초기화
        PlayerPrefs.SetInt("MiniGameScore", currentScore); // 점수 초기화 후 저장
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 현재 씬을 다시 로드
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