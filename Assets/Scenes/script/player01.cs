using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player01 : MonoBehaviour
{
    SpriteRenderer playerSprite;
    public float playerSpeed; //�̵��ӵ�
    Animator playerAnima;
    bool isMoving; //�����϶�

    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        playerAnima = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isMoving = false;

        // ������ �̵�
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Time.fixedDeltaTime * playerSpeed, 0, 0);
            playerSprite.flipX = false;
            playerAnima.SetBool("right", true);
            playerAnima.SetBool("up", false);
            playerAnima.SetBool("down", false);
            isMoving = true;
        }
        // ���� �̵�
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-Time.fixedDeltaTime * playerSpeed, 0, 0);
            playerSprite.flipX = true;
            playerAnima.SetBool("right", true);
            playerAnima.SetBool("up", false);
            playerAnima.SetBool("down", false);
            isMoving = true;
        }
        // �� �̵�
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, Time.fixedDeltaTime * playerSpeed, 0);
            playerAnima.SetBool("up", true);
            playerAnima.SetBool("right", false);
            playerAnima.SetBool("down", false);
            isMoving = true;
        }
        // �Ʒ� �̵�
        else if (Input.GetKey(KeyCode.DownArrow))
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

        // Ű�� ������ �� �ִϸ��̼� ���� ����
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "wall")
        {
            playerSprite.sortingOrder = 7;
        }
        if (collision.gameObject.tag == "wallwall")
        {
            playerSprite.sortingOrder = 2;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            playerSprite.sortingOrder = 4;
        }
        if (collision.gameObject.tag == "wallwall")
        {
            playerSprite.sortingOrder = 4;
        }
    }
}
