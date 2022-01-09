using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject startButton, restartButton, mainButton;

    //메인 씬 - Start 버튼
    public void StartGame()
    { 
        SceneManager.LoadScene("Level1Scene");
    }

    //게임오버 씬 - 메인으로 이동 버튼
    public void MainGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    //게임오버 씬 - 다시 시작 버튼
    public void RestartGame()
    {
        SceneManager.LoadScene("Level1Scene");
        PlayerPrefs.SetInt("Current Score", 0);   //현재 점수는 0으로 초기화
    }
}

