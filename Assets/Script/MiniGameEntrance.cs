using UnityEngine.SceneManagement;
using UnityEngine;

public class MiniGameEntrance : MonoBehaviour
{
    private bool isPlayerInRange = false;

    void Update()

    {
        // �÷��̾ �̴ϰ��� �Ա��� ������ ���� �� 'E' Ű�� �̴ϰ��� ����
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            LoadMiniGameScenes();
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

    void LoadMiniGameScenes()
    {
        // �̴ϰ��� �� �ε�
        SceneManager.LoadScene("MiniGameScenes");

    }

}