using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� �� - 4���� ĳ���� ����
public enum Character
{
    player, player2, player3, player4
}

//�̱��� ����
public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != null) return;

        //���� ��ȯ�Ǿ ������Ʈ�� ������� �ʵ���
        DontDestroyOnLoad(gameObject);
    }

    public Character currentCharacter;
}
