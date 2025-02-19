using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class HighScoreUIManager : MonoBehaviour
{
    public TextMeshProUGUI currentScoreText; // 현재 점수 표시 UI
    public TextMeshProUGUI highScoreText;    // 최고 점수 표시 UI
    public Button exitButton;                // Exit 버튼 (메인 씬 이동)
    public Button gameStartButton;           // Game Start 버튼 (미니게임 씬 이동)

    private int currentScore;
    private int highScore;

    void Start()
    {
        // 저장된 최고 점수 불러오기 (없으면 0)
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        // 현재 점수 불러오기 (이전 씬에서 저장한 값)
        currentScore = PlayerPrefs.GetInt("CurrentScore", 0);

        // 최고 점수 갱신
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save(); // 변경 사항 저장
        }

        // UI 업데이트
        UpdateScoreUI();

        // 버튼 이벤트 등록
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

    // 메인 씬으로 이동
    void GoToMainScene()
    {
        SceneManager.LoadScene("MainScenes");
    }

    // 미니게임 씬으로 이동
    void GoToMiniGameScene()
    {
        SceneManager.LoadScene("MiniGameScenes");
    }
}