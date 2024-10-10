using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player01 : MonoBehaviour
{
    private SpriteRenderer playerSprite;
    public float playerSpeed; // 이동속도
    private Animator playerAnima;
    private bool isMoving; // 움직일 때
    public npc01[] npcScripts; // 여러 NPC의 스크립트 배열

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

        // 대화창이 모두 비활성화되어 있을 때만 이동 가능
        bool isAnyTalkScreenActive = false;
        for (int i = 0; i < npcScripts.Length; i++)
        {
            if (npcScripts[i].talkScreen.activeSelf)
            {
                isAnyTalkScreenActive = true;
                break;
            }
        }

        // 대화창이 비활성화된 경우에만 이동
        if (!isAnyTalkScreenActive)
        {
            // 오른쪽 이동
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Time.fixedDeltaTime * playerSpeed, 0, 0);
                playerSprite.flipX = false;
                playerAnima.SetBool("right", true);
                playerAnima.SetBool("up", false);
                playerAnima.SetBool("down", false);
                isMoving = true;
            }
            // 왼쪽 이동
            else if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-Time.fixedDeltaTime * playerSpeed, 0, 0);
                playerSprite.flipX = true;
                playerAnima.SetBool("right", true);
                playerAnima.SetBool("up", false);
                playerAnima.SetBool("down", false);
                isMoving = true;
            }
            // 위로 이동
            else if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(0, Time.fixedDeltaTime * playerSpeed, 0);
                playerAnima.SetBool("up", true);
                playerAnima.SetBool("right", false);
                playerAnima.SetBool("down", false);
                isMoving = true;
            }
            // 아래로 이동
            else if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(0, -Time.fixedDeltaTime * playerSpeed, 0);
                playerAnima.SetBool("down", true);
                playerAnima.SetBool("right", false);
                playerAnima.SetBool("up", false);
                isMoving = true;
            }

            // 이동하지 않을 때 애니메이션 상태 변경
            if (!isMoving)
            {
                playerAnima.SetBool("right", false);
                playerAnima.SetBool("up", false);
                playerAnima.SetBool("down", false);
            }
        }
        else
        {
            // 대화창이 활성화되어 있으면 애니메이션 멈춤
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
