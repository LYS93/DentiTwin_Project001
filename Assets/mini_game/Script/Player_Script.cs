using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Script : MonoBehaviour
{
    Animator myAnim; //캐릭터 애니메이션
    SpriteRenderer mySr; //좌우반전
    Rigidbody2D myRigid; //중력
    Animator RB_Anim; //빨간 버튼 애니메이션
    Animator BB_Anim; //파란 버튼 애니메이션
    Animator YB_Anim; //노란 버튼 애니메이션
    BoxCollider2D RB_Col; //버튼 콜라이더
    //BoxCollider2D Empty_Col; //빈 오브젝트 콜라이더(판정만 해주는 역할)
    public GameObject T_Guide; //instantiate 생성을 위한 저장공간. > 가이드
    public GameObject Drill; //instantiate 생성 위한 저장공간. > 드릴
    public GameObject Implant; //instantiate 생성 위한 저장공간. > 임플란트 보철물
    //AudioSource myAudio;

    bool isJump = false;
    bool isTG_out = false;
    bool isDrill_out = false;
    bool isImplant_out = false;
    bool isGoal = false;

    public float jump_speed;
    public float run_speed;

    bool loadsceneend;
    float endtimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        myAnim = GetComponent<Animator>();
        mySr = GetComponent<SpriteRenderer>();
        myRigid = GetComponent<Rigidbody2D>();
        RB_Anim = GameObject.Find("Red Button").GetComponent<Animator>();
        BB_Anim = GameObject.Find("Blue Button").GetComponent<Animator>();
        YB_Anim = GameObject.Find("Yellow Button").GetComponent<Animator>();
        RB_Col = GameObject.Find("Red Button").GetComponent<BoxCollider2D>();
        //Empty_Col = GameObject.Find("col_verdict").GetComponent<BoxCollider2D>();
        transform.position = new Vector3(-7, -2, 0);

        //myAudio = GetComponent<AudioSource>();
        //myAudio.volume =  0.4f;
        //myAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGoal)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) // 위쪽 화살표 누를때 점프 && 2단점프 막기.
            {
                if (isJump == false)
                {
                    myAnim.SetBool("Jump", true);
                    myRigid.velocity = jump_speed * Vector3.up;
                    isJump = true;
                }
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) // 오른 화살표 누를 때 오른쪽으로 달리기.
            {
                mySr.flipX = false;
                myAnim.SetBool("Run", true);
                transform.Translate(run_speed * Time.deltaTime, 0, 0);
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) // 왼 화살표 누를 때 왼쪽으로 달리기.
            {
                mySr.flipX = true;
                myAnim.SetBool("Run", true);
                transform.Translate(-run_speed * Time.deltaTime, 0, 0);
            }
            else // 아무것도 누르지 않았을때 서있기.
            {
                myAnim.SetBool("Run", false);
            }
        }

        if(loadsceneend)
        {
            endtimer += Time.deltaTime;
            if (endtimer >= 3)
            {
                SceneManager.LoadScene("EndScene");
                endtimer = 0;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) // 충돌했을때
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            myAnim.SetBool("Jump", false);
            isJump = false;
        }

        if (collision.gameObject.CompareTag("Pushing Object"))
        {
            myAnim.SetBool("Jump", false);
            isJump = false;
        }

        if (collision.gameObject.CompareTag("Arrival"))
        {
            myAnim.SetBool("Jump", false);
            isJump = false;
        }

        if (collision.gameObject.CompareTag("Button"))
        {
            Debug.Log("응?");
            myAnim.SetBool("Jump", false);
            isJump = false;
            if (collision.gameObject.name == "Red Button") // 빨간버튼을 눌렀을 때 
            {
                RB_Anim.SetBool("Push", true);

                // 오류났음. 어디가? 콜라이더 크기가 계속 변하면서 
                // 콜라이더랑 닿았을때와 안닿았을때가 매 프레임마다
                // 반복되면서 오류가 생김.
                // 이 밑으로 다 오류남. 원인; 콜라이더 크기 조절 때문에.

                //B_Col.offset = new Vector2(0.005f,-0.14f);
                //여기에 instantiate으로 만들어진 가이드가 호출되도록 해보자.

                if (!isTG_out) //가이드가 한번만 출력되게끔.
                {
                    GameObject T_G = Instantiate(T_Guide);
                    T_G.transform.position = new Vector3(47.0f, -28.0f, 0.0f);
                    isTG_out = true;
                }
            }
            if (collision.gameObject.name == "Blue Button") // 파란버튼을 눌렀을 때
            {
                BB_Anim.SetBool("Push", true);

                if (!isDrill_out)
                {
                    GameObject D_Tr = Instantiate(Drill);
                    D_Tr.transform.position = new Vector3(73.5f, -35.8f, 0);
                    isDrill_out = true;
                    Destroy(GameObject.Find("dissapear tilemap"), 0.4f);

                }

                //D_Tr.transform.Translate(0, -0.4f, 0); // 점차 y값을 -0.4f를 더해주면서 밑으로 내려주기 (해결안돼서 보류)
                //if (D_Tr.position.y < 일정범위)
                //{
                //    D_Tr.position.y = 일정범위값으로 유지;
                //}
            }
            if (collision.gameObject.name == "Yellow Button") // 노란버튼을 눌렀을 때
            {
                YB_Anim.SetBool("Push", true);

                if (!isImplant_out)
                {
                    GameObject IM_Tr = Instantiate(Implant);
                    IM_Tr.transform.position = new Vector3(101.5f, -36.2f, 0);
                    isImplant_out = true;
                }


            }

        }
        if (collision.gameObject.CompareTag("Guide")) // 오류있음 잡아야함.
        {
            Debug.Log("왜 안되지?");
            myAnim.SetBool("Jump", false);
            isJump = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Button")) 
            // 오류 나서 collisionexit말고 다른 식으로 접근해야할것 같다.
            // OnTriggerExit을 사용해라. 
        {
            if (collision.gameObject.name == "Red Button")
            {
                RB_Anim.SetBool("Push", false);
                //B_Col.offset = new Vector2(0.005f, 0.31f);
            }

            if (collision.gameObject.name == "Blue Button")
            {
                BB_Anim.SetBool("Push", false);
                //B_Col.offset = new Vector2(0.005f, 0.31f);
            }

            if (collision.gameObject.name == "Yellow Button")
            {
                YB_Anim.SetBool("Push", false);
                //B_Col.offset = new Vector2(0.005f, 0.31f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Ending")
        {
            myAnim.SetTrigger("Goal");
            isGoal = true;

            loadsceneend = true;
            Debug.Log("몇초뒤에 엔딩으로 넘어갑니다. 여기는 유석님이 다음씬 넣어줄 자리.");
        }
    }
}
