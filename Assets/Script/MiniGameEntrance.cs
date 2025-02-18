using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameEntrance : MonoBehaviour
{
    private bool isPlayerInRange = false;

    void Update()
    {
        // �÷��̾ �̴ϰ��� �Ա��� ������ ���� �� 'E' Ű�� �̴ϰ��� ����
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            LoadMiniGameScene();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // �÷��̾ �Ա��� �������� ��
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // �÷��̾ �Ա��� ����� ��
        {
            isPlayerInRange = false;
        }
    }

    void LoadMiniGameScene()
    {
        // �̴ϰ��� �� �ε�
        SceneManager.LoadScene("MiniGameScene"); // "MiniGameScene"�� �̴ϰ��� ���� �̸����� ����
    }
}