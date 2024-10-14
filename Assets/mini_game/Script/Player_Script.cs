using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Script : MonoBehaviour
{
    Animator myAnim; //ĳ���� �ִϸ��̼�
    SpriteRenderer mySr; //�¿����
    Rigidbody2D myRigid; //�߷�
    Animator RB_Anim; //���� ��ư �ִϸ��̼�
    Animator BB_Anim; //�Ķ� ��ư �ִϸ��̼�
    Animator YB_Anim; //��� ��ư �ִϸ��̼�
    BoxCollider2D RB_Col; //��ư �ݶ��̴�
    //BoxCollider2D Empty_Col; //�� ������Ʈ �ݶ��̴�(������ ���ִ� ����)
    public GameObject T_Guide; //instantiate ������ ���� �������. > ���̵�
    public GameObject Drill; //instantiate ���� ���� �������. > �帱
    public GameObject Implant; //instantiate ���� ���� �������. > ���ö�Ʈ ��ö��
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
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) // ���� ȭ��ǥ ������ ���� && 2������ ����.
            {
                if (isJump == false)
                {
                    myAnim.SetBool("Jump", true);
                    myRigid.velocity = jump_speed * Vector3.up;
                    isJump = true;
                }
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) // ���� ȭ��ǥ ���� �� ���������� �޸���.
            {
                mySr.flipX = false;
                myAnim.SetBool("Run", true);
                transform.Translate(run_speed * Time.deltaTime, 0, 0);
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) // �� ȭ��ǥ ���� �� �������� �޸���.
            {
                mySr.flipX = true;
                myAnim.SetBool("Run", true);
                transform.Translate(-run_speed * Time.deltaTime, 0, 0);
            }
            else // �ƹ��͵� ������ �ʾ����� ���ֱ�.
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

    private void OnCollisionEnter2D(Collision2D collision) // �浹������
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
            Debug.Log("��?");
            myAnim.SetBool("Jump", false);
            isJump = false;
            if (collision.gameObject.name == "Red Button") // ������ư�� ������ �� 
            {
                RB_Anim.SetBool("Push", true);

                // ��������. ���? �ݶ��̴� ũ�Ⱑ ��� ���ϸ鼭 
                // �ݶ��̴��� ��������� �ȴ�������� �� �����Ӹ���
                // �ݺ��Ǹ鼭 ������ ����.
                // �� ������ �� ������. ����; �ݶ��̴� ũ�� ���� ������.

                //B_Col.offset = new Vector2(0.005f,-0.14f);
                //���⿡ instantiate���� ������� ���̵尡 ȣ��ǵ��� �غ���.

                if (!isTG_out) //���̵尡 �ѹ��� ��µǰԲ�.
                {
                    GameObject T_G = Instantiate(T_Guide);
                    T_G.transform.position = new Vector3(47.0f, -28.0f, 0.0f);
                    isTG_out = true;
                }
            }
            if (collision.gameObject.name == "Blue Button") // �Ķ���ư�� ������ ��
            {
                BB_Anim.SetBool("Push", true);

                if (!isDrill_out)
                {
                    GameObject D_Tr = Instantiate(Drill);
                    D_Tr.transform.position = new Vector3(73.5f, -35.8f, 0);
                    isDrill_out = true;
                    Destroy(GameObject.Find("dissapear tilemap"), 0.4f);

                }

                //D_Tr.transform.Translate(0, -0.4f, 0); // ���� y���� -0.4f�� �����ָ鼭 ������ �����ֱ� (�ذ�ȵż� ����)
                //if (D_Tr.position.y < ��������)
                //{
                //    D_Tr.position.y = �������������� ����;
                //}
            }
            if (collision.gameObject.name == "Yellow Button") // �����ư�� ������ ��
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
        if (collision.gameObject.CompareTag("Guide")) // �������� ��ƾ���.
        {
            Debug.Log("�� �ȵ���?");
            myAnim.SetBool("Jump", false);
            isJump = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Button")) 
            // ���� ���� collisionexit���� �ٸ� ������ �����ؾ��Ұ� ����.
            // OnTriggerExit�� ����ض�. 
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
            Debug.Log("���ʵڿ� �������� �Ѿ�ϴ�. ����� �������� ������ �־��� �ڸ�.");
        }
    }
}
