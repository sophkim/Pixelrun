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

    //���ȭ�� �� ȿ���� ����
    AudioSource audioSource;
    public AudioClip audioJump;
    public AudioClip audioHit;
    public AudioClip audioItem;

    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.audioSource = GetComponent<AudioSource>();

        //���� ���� 0���� �ʱ�ȭ
        PlayerPrefs.SetInt("Current Score", 0);
    }

    void Update()
    {
        //�����Ѵ�
        if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
            animator.SetBool("isJump", true); //���� �ִϸ��̼� ����
            PlaySound("JUMP"); //���� ȿ����
        }
        else
        {
            animator.SetBool("isJump", false); //���� �ִϸ��̼� ����
        }

        //�¿� �̵�
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) //������
        {
            key = 1; 
        }
        if (Input.GetKey(KeyCode.LeftArrow)) //����
        {
            key = -1;
        }

        //�÷��̾��� �ӵ�
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        //���ǵ� ����
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        //�����̴� ���⿡ ���� �����Ѵ�.
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        //�÷��̾� �ӵ��� ���� �ִϸ��̼� �ӵ��� �ٲ۴�.
        this.animator.speed = speedx / 2.0f;

        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    //Collision
    void OnCollisionEnter2D(Collision2D col)
    {
        //Traps�� �±׵� ��ֹ��̳� ���Ϳ� ������
        if (col.gameObject.tag == "Traps") 
        {
            Debug.Log("Hit");
            HpManager.hp -= 1; //hp 1����
            animator.SetBool("isHit", true); //Hit �ִϸ��̼� ����
            PlaySound("HIT"); //ȿ���� ����
        }
        else
        {
            animator.SetBool("isHit", false); //Hit �ִϸ��̼� ����
        }
    }

    //Trigger
    void OnTriggerEnter2D(Collider2D col)
    {
        //�������� ����ϸ�
        if (col.gameObject.tag == "Items")
        {
            Debug.Log("Item!");
            col.gameObject.SetActive(false); //�÷��̾�� ���� ������ ���ֱ�
            PlaySound("ITEM"); //ȿ���� ����

            GameObject smObject = GameObject.Find("ScoreManager");
            ScoreManager sm = smObject.GetComponent<ScoreManager>();
            sm.currentScore++; //���ھ� �Ŵ����� ���� ���� 1 ����
            sm.currentScoreUI.text = "Score : " + sm.currentScore; //UI�� ���� ���� ǥ��

            PlayerPrefs.SetInt("Current Score", sm.currentScore); //���� ���� ������ ����

            //best ���ھ� ����
            if (sm.currentScore > sm.bestScore) //���� ������ �ְ� ���� �̻��� �Ǹ�
            {
                sm.bestScore = sm.currentScore;
                sm.bestScoreUI.text = "Best " + sm.bestScore;
                PlayerPrefs.SetInt("Best Score", sm.bestScore);
            }
        }

        //ū ������ ������ ���ھ� 5����
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

            //best ���ھ� ����
            if (sm.currentScore > sm.bestScore)
            {
                sm.bestScore = sm.currentScore;
                sm.bestScoreUI.text = "Best " + sm.bestScore;
                PlayerPrefs.SetInt("Best Score", sm.bestScore);
            }
        }

        //Level1 ����� ���� ��, Level2 ������ �̵�
        if (col.gameObject.name == "EndPoint1")
        {
            Debug.Log("GOAL!");
            SceneManager.LoadScene("Level2Scene");
        }

        //Level2 ����� ���� ��, Level3 ������ �̵�
        if (col.gameObject.name == "EndPoint2")
        {
            Debug.Log("GOAL!");
            SceneManager.LoadScene("Level3Scene");
        }

        //Level3 ����� ���� ��, Finish Game������ �̵�
        if (col.gameObject.name == "EndPoint3")
        {
            Debug.Log("GOAL!");
            SceneManager.LoadScene("FinishScene");
        }
    }

    //��Ȳ �� ȿ���� ����
    void PlaySound(string action)
    {
        switch (action)
        {
            case "JUMP": //������ ��
                audioSource.clip = audioJump;
                break;
            case "HIT": //��ֹ��� ���� ��
                audioSource.clip = audioHit;
                break;
            case "ITEM": //������ ���� ��
                audioSource.clip = audioItem;
                break;
        }
        audioSource.Play();
    }
}

