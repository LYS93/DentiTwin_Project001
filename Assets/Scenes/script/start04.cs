using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class start04 : MonoBehaviour
{
    bool moveStart;

    void Awake()
    {
        float savedRestart = PlayerPrefs.GetFloat("Restart");//Restart값을 가져옴

        //저장된 restart가 1보다 클때(즉, 뒤로가기로 다시 시작화면으로 왔을때)
        if (savedRestart >= 1)
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        
        if (Input.anyKeyDown)
        {
            moveStart = true;
        }

        if (moveStart)
        {
            transform.Translate(2 * Time.deltaTime, 0, 0);
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("hospital"))
        {
            Destroy(this.gameObject);
        }
    }
}
