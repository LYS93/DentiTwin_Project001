using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ending03 : MonoBehaviour
{
    public GameObject[] backgrounds; // 3개의 배경 스프라이트
    public float speed = 2f; // 이동 속도
    public float customWidth = 20.48f; // 배경의 고정 너비 (수치로 직접 지정)
    public ending01 endScript;

    void Start()
    {
        // 배경을 초기 위치에 배치
        for (int i = 0; i < backgrounds.Length; i++)
        {
            Vector3 newPos = new Vector3(i * customWidth, backgrounds[i].transform.position.y, backgrounds[i].transform.position.z);
            backgrounds[i].transform.position = newPos;
        }
    }

    void Update()
    {
        if (!endScript.isLastMessageDisplayed)
        {
            for (int i = 0; i < backgrounds.Length; i++)
            {
                // 각 배경 스프라이트를 왼쪽으로 이동
                backgrounds[i].transform.position += Vector3.left * speed * Time.deltaTime;

                // 배경이 화면 왼쪽 밖으로 나가면, 다시 오른쪽 끝으로 이동시킴
                if (backgrounds[i].transform.position.x <= -customWidth)
                {
                    // 마지막 배경의 오른쪽 끝에 고정 너비만큼 이어서 배치
                    Vector3 newPos = backgrounds[i].transform.position;
                    newPos.x += customWidth * backgrounds.Length; // 고정 너비만큼 이동
                    backgrounds[i].transform.position = newPos;
                }
            }
        }
    }
}
