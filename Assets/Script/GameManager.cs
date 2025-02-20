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
        // ����� ���� �ҷ�����
        currentScore = PlayerPrefs.GetInt("CurrentScore", 0);
        uiManager.UpdateScore(currentScore);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        PlayerPrefs.SetInt("CurrentScore", currentScore); // ���� ���� ����
        PlayerPrefs.Save();
        uiManager.SetRestart();
    }

    public void RestartGame()
    {
        currentScore = 0;  // ���� ������ �ʱ�ȭ
        PlayerPrefs.SetInt("CurrentScore", currentScore); // ���� �ʱ�ȭ �� ����
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // ���� ���� �ٽ� �ε�
    }

    public void AddScore(int score)
    {
        currentScore += score;
        uiManager.UpdateScore(currentScore);

        // ���� ����
        PlayerPrefs.SetInt("CurrentScore", currentScore);
        PlayerPrefs.Save();

        Debug.Log("Score: " + currentScore);
    }

}