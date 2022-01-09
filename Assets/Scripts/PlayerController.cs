using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;

    //배경화면 및 효과음 설정
    AudioSource audioSource;
    public AudioClip audioJump;
    public AudioClip audioHit;
    public AudioClip audioItem;

    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.audioSource = GetComponent<AudioSource>();

        //현재 점수 0으로 초기화
        PlayerPrefs.SetInt("Current Score", 0);
    }

    void Update()
    {
        //점프한다
        if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
            animator.SetBool("isJump", true); //점프 애니메이션 설정
            PlaySound("JUMP"); //점프 효과음
        }
        else
        {
            animator.SetBool("isJump", false); //점프 애니메이션 해제
        }

        //좌우 이동
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) //오른쪽
        {
            key = 1; 
        }
        if (Input.GetKey(KeyCode.LeftArrow)) //왼쪽
        {
            key = -1;
        }

        //플레이어의 속도
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        //스피드 제한
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        //움직이는 방향에 따라 반전한다.
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        //플레이어 속도에 맞춰 애니메이션 속도를 바꾼다.
        this.animator.speed = speedx / 2.0f;

        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    //Collision
    void OnCollisionEnter2D(Collision2D col)
    {
        //Traps로 태그된 장애물이나 몬스터에 닿으면
        if (col.gameObject.tag == "Traps") 
        {
            Debug.Log("Hit");
            HpManager.hp -= 1; //hp 1감소
            animator.SetBool("isHit", true); //Hit 애니메이션 설정
            PlaySound("HIT"); //효과음 성정
        }
        else
        {
            animator.SetBool("isHit", false); //Hit 애니메이션 해제
        }
    }

    //Trigger
    void OnTriggerEnter2D(Collider2D col)
    {
        //아이템을 통과하면
        if (col.gameObject.tag == "Items")
        {
            Debug.Log("Item!");
            col.gameObject.SetActive(false); //플레이어와 닿은 아이템 없애기
            PlaySound("ITEM"); //효과음 설정

            GameObject smObject = GameObject.Find("ScoreManager");
            ScoreManager sm = smObject.GetComponent<ScoreManager>();
            sm.currentScore++; //스코어 매니저의 현재 점수 1 증가
            sm.currentScoreUI.text = "Score : " + sm.currentScore; //UI에 현재 점수 표기

            PlayerPrefs.SetInt("Current Score", sm.currentScore); //현재 점수 데이터 저장

            //best 스코어 갱신
            if (sm.currentScore > sm.bestScore) //현재 점수가 최고 점수 이상이 되면
            {
                sm.bestScore = sm.currentScore;
                sm.bestScoreUI.text = "Best " + sm.bestScore;
                PlayerPrefs.SetInt("Best Score", sm.bestScore);
            }
        }

        //큰 아이템 먹으면 스코어 5증가
        if (col.gameObject.tag == "BigItems")
        {
            Debug.Log("Big Item!");
            col.gameObject.SetActive(false);
            PlaySound("ITEM");

            GameObject smObject = GameObject.Find("ScoreManager");
            ScoreManager sm = smObject.GetComponent<ScoreManager>();
            sm.currentScore+=5;
            sm.currentScoreUI.text = "Score : " + sm.currentScore;

            PlayerPrefs.SetInt("Current Score", sm.currentScore);

            //best 스코어 갱신
            if (sm.currentScore > sm.bestScore)
            {
                sm.bestScore = sm.currentScore;
                sm.bestScoreUI.text = "Best " + sm.bestScore;
                PlayerPrefs.SetInt("Best Score", sm.bestScore);
            }
        }

        //Level1 결승점 도달 시, Level2 씬으로 이동
        if (col.gameObject.name == "EndPoint1")
        {
            Debug.Log("GOAL!");
            SceneManager.LoadScene("Level2Scene");
        }

        //Level2 결승점 도달 시, Level3 낀으로 이동
        if (col.gameObject.name == "EndPoint2")
        {
            Debug.Log("GOAL!");
            SceneManager.LoadScene("Level3Scene");
        }

        //Level3 결승점 도달 시, Finish Game씬으로 이동
        if (col.gameObject.name == "EndPoint3")
        {
            Debug.Log("GOAL!");
            SceneManager.LoadScene("FinishScene");
        }
    }

    //상황 별 효과음 설정
    void PlaySound(string action)
    {
        switch (action)
        {
            case "JUMP": //점프할 때
                audioSource.clip = audioJump;
                break;
            case "HIT": //장애물에 닿을 때
                audioSource.clip = audioHit;
                break;
            case "ITEM": //아이템 먹을 때
                audioSource.clip = audioItem;
                break;
        }
        audioSource.Play();
    }
}

