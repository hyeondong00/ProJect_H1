using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour


{
    static GameManager gameManager;
    public static GameManager Instance
    {
        get { return gameManager; }
    }

    private int currentScore = 0;
    MiniGameUIManager uiManager;

    public MiniGameUIManager UIManager
    {
        get { return uiManager; }
    }

    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<MiniGameUIManager>();
    }

    private void Start()
    {
        // 저장된 점수 불러오기
        currentScore = PlayerPrefs.GetInt("CurrentScore", 0);
        uiManager.UpdateScore(currentScore);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        PlayerPrefs.SetInt("CurrentScore", currentScore); // 현재 점수 저장
        PlayerPrefs.Save();
        uiManager.SetRestart();
    }

    public void RestartGame()
    {
        currentScore = 0;  // 현재 점수를 초기화
        PlayerPrefs.SetInt("CurrentScore", currentScore); // 점수 초기화 후 저장
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // 현재 씬을 다시 로드
    }

    public void AddScore(int score)
    {
        currentScore += score;
        uiManager.UpdateScore(currentScore);

        // 점수 저장
        PlayerPrefs.SetInt("CurrentScore", currentScore);
        PlayerPrefs.Save();

        Debug.Log("Score: " + currentScore);
    }

}