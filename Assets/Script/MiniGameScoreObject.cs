using UnityEngine;

public class MiniGameScoreObject : MonoBehaviour
{
    public Canvas scoreCanvas;  // 해당 오브젝트에 붙어있는 캔버스를 참조
    private bool isPlayerInRange = false;  // 플레이어가 콜라이더 범위에 들어왔는지 여부
    private bool isCanvasVisible = false;  // 캔버스가 보이는지 여부

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // E키를 눌렀을 때 캔버스를 토글
            ToggleCanvas(!isCanvasVisible);
        }

        // 상호작용을 하지 않고 다른 곳을 클릭하면 캔버스를 비활성화
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleCanvas(false);
        }
    }

    // 플레이어가 Collider 범위에 들어왔을 때 호출
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // 플레이어 태그를 확인
        {
            isPlayerInRange = true;
            Debug.Log("Press 'E' to interact.");
        }
    }

    // 플레이어가 Collider 범위에서 나갔을 때 호출
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // 플레이어 태그를 확인
        {
            isPlayerInRange = false;
            Debug.Log("You are too far to interact.");
        }
    }

    // 캔버스를 활성화하거나 비활성화하는 함수
    private void ToggleCanvas(bool state)
    {
        if (scoreCanvas != null)
        {
            scoreCanvas.gameObject.SetActive(state);
            isCanvasVisible = state;  // 캔버스 상태를 업데이트
        }
    }
}