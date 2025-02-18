using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameController : MonoBehaviour
{
    public void EndMiniGame()
    {
        // 원래 씬으로 돌아가기 (예: "MainScene" 씬으로)
        SceneManager.LoadScene("MainScene");
    }
}