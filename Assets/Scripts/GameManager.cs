using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject startButton, restartButton, mainButton;

    //���� �� - Start ��ư
    public void StartGame()
    { 
        SceneManager.LoadScene("Level1Scene");
    }

    //���ӿ��� �� - �������� �̵� ��ư
    public void MainGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    //���ӿ��� �� - �ٽ� ���� ��ư
    public void RestartGame()
    {
        SceneManager.LoadScene("Level1Scene");
        PlayerPrefs.SetInt("Current Score", 0);   //���� ������ 0���� �ʱ�ȭ
    }
}

