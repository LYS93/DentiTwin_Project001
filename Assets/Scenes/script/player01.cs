using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player01 : MonoBehaviour
{
    SpriteRenderer playerSprite;
    public float playerSpeed; //이동속도
    Animator playerAnima;
    bool isMoving; //움직일때
    npc01 npcScript;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        playerAnima = GetComponent<Animator>();
        npcScript = GameObject.Find("Collider").GetComponent<npc01>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isMoving = false;

        //대화창이 활성화되면 이동중지
        if (!npcScript.talkScreen.activeSelf)
        {
            //애니메이션 재생
            playerAnima.speed = 1;
            // 오른쪽 이동
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Time.fixedDeltaTime * playerSpeed, 0, 0);
                playerSprite.flipX = false;
                playerAnima.SetBool("right", true);
                playerAnima.SetBool("up", false);
                playerAnima.SetBool("down", false);
                isMoving = true;
            }
            // 왼쪽 이동
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(-Time.fixedDeltaTime * playerSpeed, 0, 0);
                playerSprite.flipX = true;
                playerAnima.SetBool("right", true);
                playerAnima.SetBool("up", false);
                playerAnima.SetBool("down", false);
                isMoving = true;
            }
            // 위 이동
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(0, Time.fixedDeltaTime * playerSpeed, 0);
                playerAnima.SetBool("up", true);
                playerAnima.SetBool("right", false);
                playerAnima.SetBool("down", false);
                isMoving = true;
            }
            // 아래 이동
            else if (Input.GetKey(KeyCode.DownArrow))
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

            // 키를 놓았을 때 애니메이션 상태 변경
            if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                playerAnima.SetBool("right", false);
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                playerAnima.SetBool("up", false);
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                playerAnima.SetBool("down", false);
            }
        }
        
        //대화창이 활성화 상태일때
        if (npcScript.talkScreen.activeSelf)
        {
            playerAnima.speed = 0;//애니메이션 중지
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("wall"))
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
