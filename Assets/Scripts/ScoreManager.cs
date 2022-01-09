using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // ���� ����
    public Text currentScoreUI;
    public int currentScore;

    // �ְ� ����
    public Text bestScoreUI;
    public int bestScore;

    void Start()
    {
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        bestScoreUI.text = "Best " + bestScore;

        currentScore = PlayerPrefs.GetInt("Current Score", 0);
        currentScoreUI.text = "Score : " + currentScore;
    }
}

