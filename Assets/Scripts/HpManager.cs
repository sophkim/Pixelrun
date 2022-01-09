using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HpManager : MonoBehaviour
{
    //��� �̹����� ������ hp �ʱⰪ�� 5�� ����
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
        //��ֹ��� �ε��� hp�� ������ ������ ��� �̹��� �� ���� ���ֱ�
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
                SceneManager.LoadScene("GameOver"); //hp�� 0�̵Ǹ� ���ӿ��� ������ �̵�
                break;
        }
    }
}
