using UnityEngine;

public class MiniGameScoreObject : MonoBehaviour
{
    public Canvas scoreCanvas;  // �ش� ������Ʈ�� �پ��ִ� ĵ������ ����
    private bool isPlayerInRange = false;  // �÷��̾ �ݶ��̴� ������ ���Դ��� ����
    private bool isCanvasVisible = false;  // ĵ������ ���̴��� ����

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // EŰ�� ������ �� ĵ������ ���
            ToggleCanvas(!isCanvasVisible);
        }

        // ��ȣ�ۿ��� ���� �ʰ� �ٸ� ���� Ŭ���ϸ� ĵ������ ��Ȱ��ȭ
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleCanvas(false);
        }
    }

    // �÷��̾ Collider ������ ������ �� ȣ��
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // �÷��̾� �±׸� Ȯ��
        {
            isPlayerInRange = true;
            Debug.Log("Press 'E' to interact.");
        }
    }

    // �÷��̾ Collider �������� ������ �� ȣ��
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // �÷��̾� �±׸� Ȯ��
        {
            isPlayerInRange = false;
            Debug.Log("You are too far to interact.");
        }
    }

    // ĵ������ Ȱ��ȭ�ϰų� ��Ȱ��ȭ�ϴ� �Լ�
    private void ToggleCanvas(bool state)
    {
        if (scoreCanvas != null)
        {
            scoreCanvas.gameObject.SetActive(state);
            isCanvasVisible = state;  // ĵ���� ���¸� ������Ʈ
        }
    }
}