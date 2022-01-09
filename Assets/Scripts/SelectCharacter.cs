using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{
    //메인화면 - 캐릭터 선택 씬
    public Character character;
    Animator animator;
    public SelectCharacter[] chars;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (DataManager.instance.currentCharacter == character) OnSelect();
        else OnDeSelect();
    }

    private void OnMouseUpAsButton()
    {
        DataManager.instance.currentCharacter = character;
        OnSelect();

        for(int i = 0; i < chars.Length; i++)
        {
            if (chars[i] != this) chars[i].OnDeSelect();
        }
    }

    //캐릭터 클릭 시 애니메이션 효과 적용
    void OnSelect()
    {
        animator.SetBool("isHit", true);
    }

    //캐릭터 한 번 더 클릭 시 애니메이션 효과 해제
    void OnDeSelect()
    {
        animator.SetBool("isHit", false);
    }
}
