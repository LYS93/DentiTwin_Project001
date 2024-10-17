using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Foot_Script : MonoBehaviour
{
    Animator P_Anim;
    Rigidbody2D P_Rigid;

    bool isJump = false;
    
    public float jump_speed;

    // Start is called before the first frame update
    void Start()
    {
        P_Anim = GameObject.Find("Player").GetComponent<Animator>();
        P_Rigid = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) // 위쪽 화살표 누를때 점프 && 2단점프 막기.
        {
            if (isJump == false)
            {
                P_Anim.SetBool("Jump", true);
                P_Rigid.velocity = jump_speed * Vector3.up;
                isJump = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) // 충돌했을때
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            
            isJump = false;
        }

        if (collision.gameObject.CompareTag("Pushing Object"))
        {
            
            isJump = false;
        }

        if (collision.gameObject.CompareTag("Arrival"))
        {
           
            isJump = false;
        }

        if (collision.gameObject.CompareTag("Button"))
        {
            
            isJump = false;
        }

        if (collision.gameObject.CompareTag("Guide")) // 오류있음 잡아야함.
        {
            
            isJump = false;
        }
    }
}
