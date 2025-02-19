using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class HighScoreUIManager : MonoBehaviour
{
    public TextMeshProUGUI currentScoreText; // ���� ���� ǥ�� UI
    public TextMeshProUGUI highScoreText;    // �ְ� ���� ǥ�� UI
    public Button exitButton;                // Exit ��ư (���� �� �̵�)
    public Button gameStartButton;           // Game Start ��ư (�̴ϰ��� �� �̵�)

    private int currentScore;
    private int highScore;

    void Start()
    {
        // ����� �ְ� ���� �ҷ����� (������ 0)
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        // ���� ���� �ҷ����� (���� ������ ������ ��)
        currentScore = PlayerPrefs.GetInt("CurrentScore", 0);

        // �ְ� ���� ����
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save(); // ���� ���� ����
        }

        // UI ������Ʈ
        UpdateScoreUI();

        // ��ư �̺�Ʈ ���
        if (exitButton != null)
            exitButton.onClick.AddListener(GoToMainScene);

        if (gameStartButton != null)
            gameStartButton.onClick.AddListener(GoToMiniGameScene);
    }

    void UpdateScoreUI()
    {
        currentScoreText.text = "" + currentScore;
        highScoreText.text = "" + highScore;
    }

    // ���� ������ �̵�
    void GoToMainScene()
    {
        SceneManager.LoadScene("MainScenes");
    }

    // �̴ϰ��� ������ �̵�
    void GoToMiniGameScene()
    {
        SceneManager.LoadScene("MiniGameScenes");
    }
}