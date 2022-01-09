using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//메인 씬 - 4개의 캐릭터 설정
public enum Character
{
    player, player2, player3, player4
}

//싱글톤 패턴
public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != null) return;

        //씬이 전환되어도 오브젝트가 사라지지 않도록
        DontDestroyOnLoad(gameObject);
    }

    public Character currentCharacter;
}
