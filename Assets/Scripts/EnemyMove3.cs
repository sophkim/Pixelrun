using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove3 : MonoBehaviour
{
    Vector2 pos; //현재 위치
    float delta = 1.6f; //좌우 이동 최대값
    float speed = 0.8f; //이동속도

    void Start()
    {
        //현재 위치 저장
        pos = transform.position;
    }


    void Update()
    {
        Vector2 v = pos;
        v.x -= delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }
}