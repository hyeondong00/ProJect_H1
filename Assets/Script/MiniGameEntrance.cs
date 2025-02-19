using UnityEngine.SceneManagement;
using UnityEngine;

public class MiniGameEntrance : MonoBehaviour
{
    private bool isPlayerInRange = false;

    void Update()

    {
        // 플레이어가 미니게임 입구에 가까이 있을 때 'E' 키로 미니게임 시작
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            LoadMiniGameScenes();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // 플레이어가 입구에 접촉했을 때
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // 플레이어가 입구를 벗어났을 때
        {
            isPlayerInRange = false;
        }
    }

    void LoadMiniGameScenes()
    {
        // 미니게임 씬 로드
        SceneManager.LoadScene("MiniGameScenes");

    }

}