using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawn : MonoBehaviour
{
    public GameObject[] charPrefabs;
    public GameObject player;

    //���ξ����� ������ ĳ���͸� ����ȭ�� startPoint�� ��ġ
    void Start()
    {
        player = Instantiate(charPrefabs[(int)DataManager.instance.currentCharacter]);
        player.transform.position = transform.position;
    }

}
