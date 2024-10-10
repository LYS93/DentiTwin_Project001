using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player01 : MonoBehaviour
{
    private SpriteRenderer playerSprite;
    public float playerSpeed; // �̵��ӵ�
    private Animator playerAnima;
    private bool isMoving; // ������ ��
    public npc01[] npcScripts; // ���� NPC�� ��ũ��Ʈ �迭

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        playerAnima = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        isMoving = false;

        // ��ȭâ�� ��� ��Ȱ��ȭ�Ǿ� ���� ���� �̵� ����
        bool isAnyTalkScreenActive = false;
        for (int i = 0; i < npcScripts.Length; i++)
        {
            if (npcScripts[i].talkScreen.activeSelf)
            {
                isAnyTalkScreenActive = true;
                break;
            }
        }

        // ��ȭâ�� ��Ȱ��ȭ�� ��쿡�� �̵�
        if (!isAnyTalkScreenActive)
        {
            // ������ �̵�
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Time.fixedDeltaTime * playerSpeed, 0, 0);
                playerSprite.flipX = false;
                playerAnima.SetBool("right", true);
                playerAnima.SetBool("up", false);
                playerAnima.SetBool("down", false);
                isMoving = true;
            }
            // ���� �̵�
            else if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-Time.fixedDeltaTime * playerSpeed, 0, 0);
                playerSprite.flipX = true;
                playerAnima.SetBool("right", true);
                playerAnima.SetBool("up", false);
                playerAnima.SetBool("down", false);
                isMoving = true;
            }
            // ���� �̵�
            else if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(0, Time.fixedDeltaTime * playerSpeed, 0);
                playerAnima.SetBool("up", true);
                playerAnima.SetBool("right", false);
                playerAnima.SetBool("down", false);
                isMoving = true;
            }
            // �Ʒ��� �̵�
            else if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(0, -Time.fixedDeltaTime * playerSpeed, 0);
                playerAnima.SetBool("down", true);
                playerAnima.SetBool("right", false);
                playerAnima.SetBool("up", false);
                isMoving = true;
            }

            // �̵����� ���� �� �ִϸ��̼� ���� ����
            if (!isMoving)
            {
                playerAnima.SetBool("right", false);
                playerAnima.SetBool("up", false);
                playerAnima.SetBool("down", false);
            }
        }
        else
        {
            // ��ȭâ�� Ȱ��ȭ�Ǿ� ������ �ִϸ��̼� ����
            playerAnima.speed = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            playerSprite.sortingOrder = 7;
        }
        if (collision.gameObject.CompareTag("wallwall"))
        {
            playerSprite.sortingOrder = 2;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            playerSprite.sortingOrder = 4;
        }
        if (collision.gameObject.CompareTag("wallwall"))
        {
            playerSprite.sortingOrder = 4;
        }
    }
}
