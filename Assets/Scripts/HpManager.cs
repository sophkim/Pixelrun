using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HpManager : MonoBehaviour
{
    //사과 이미지로 구성된 hp 초기값을 5로 설정
    public static int hp = 5;
    public GameObject life1, life2, life3, life4, life5;

    void Start()
    {
        hp = 5;
        life1.gameObject.SetActive(true);
        life2.gameObject.SetActive(true);
        life3.gameObject.SetActive(true);
        life4.gameObject.SetActive(true);
        life5.gameObject.SetActive(true);
    }

    void Update()
    {
        //장애물에 부딪혀 hp가 감소할 때마다 사과 이미지 한 개씩 없애기
        switch (hp)
        {
            case 4:
                life5.gameObject.SetActive(false);
                break;
            case 3:
                life4.gameObject.SetActive(false);
                break;
            case 2:
                life3.gameObject.SetActive(false);
                break;
            case 1:
                life2.gameObject.SetActive(false);
                break;
            case 0:
                life1.gameObject.SetActive(false);
                SceneManager.LoadScene("GameOver"); //hp가 0이되면 게임오버 씬으로 이동
                break;
        }
    }
}
