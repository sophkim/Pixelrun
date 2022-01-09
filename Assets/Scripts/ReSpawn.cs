using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawn : MonoBehaviour
{
    public GameObject[] charPrefabs;
    public GameObject player;

    //메인씬에서 선택한 캐릭터를 게임화면 startPoint에 배치
    void Start()
    {
        player = Instantiate(charPrefabs[(int)DataManager.instance.currentCharacter]);
        player.transform.position = transform.position;
    }

}
