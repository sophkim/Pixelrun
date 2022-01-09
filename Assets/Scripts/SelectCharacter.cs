using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{
    //����ȭ�� - ĳ���� ���� ��
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

    //ĳ���� Ŭ�� �� �ִϸ��̼� ȿ�� ����
    void OnSelect()
    {
        animator.SetBool("isHit", true);
    }

    //ĳ���� �� �� �� Ŭ�� �� �ִϸ��̼� ȿ�� ����
    void OnDeSelect()
    {
        animator.SetBool("isHit", false);
    }
}
