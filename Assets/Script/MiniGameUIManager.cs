using System;
using System.Collections;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniGameUIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI returnMainScenes;
    public Button returnButton; // �߰�

    public void Start()
    {
        if (restartText == null)
        {
            Debug.LogError("restartText is null");
        }

        if (scoreText == null)
        {
            Debug.LogError("scoreText is null");
            return;
        }

        if (returnMainScenes == null)
        {
            Debug.LogError("returnMainScenes is null");
        }

        if (returnButton == null)
        {
            Debug.LogError("returnButton is null");
        }
        else
        {
            returnButton.onClick.AddListener(ReturnToMainScene); // ��ư Ŭ�� �̺�Ʈ ����
        }

        restartText.gameObject.SetActive(false);
    }

    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void ReturnToMainScene()
    {
        SceneManager.LoadScene("MainScenes"); // "MainScenes" ������ �̵�
    }
}