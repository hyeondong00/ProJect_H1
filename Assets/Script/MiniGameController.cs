using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameController : MonoBehaviour
{
    public void EndMiniGame()
    {
        // ���� ������ ���ư��� (��: "MainScene" ������)
        SceneManager.LoadScene("MainScene");
    }
}