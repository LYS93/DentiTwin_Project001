using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class start02 : MonoBehaviour
{
    
    public Text startText; // 시작스크린 글씨(게임을 시작하려면 아무키나 누르세요)
    float blinkInterval = 0.5f; // 깜빡이는 간격
    private float timer = 0f; // 타이머 변수
    private bool isTextVisible = true; // 텍스트 보이는 상태

    public Image blink;
    private float timer2 = 0f; // 타이머 변수2
    bool isImageVisible = false; // 점멸스크린 보이는 상태
    float blinkInterval2 = 0.08f; // 깜빡이는 간격2
    private bool isBlinking = false; //깜빡이는 상태


    private void Awake()
    {
        float savedRestart = PlayerPrefs.GetFloat("Restart");//Restart값을 가져옴

        //저장된 restart가 1보다 클때(즉, 뒤로가기로 다시 시작화면으로 왔을때)
        if (savedRestart >= 1)
        {
            Destroy(gameObject);// 이 GameObject를 파괴
            PlayerPrefs.DeleteKey("Restart");//Restart값 초기화
        }
        else
        {
            PlayerPrefs.DeleteAll(); // 모든 PlayerPrefs 삭제
            PlayerPrefs.Save(); // 변경사항 저장
        }
        
        blink.enabled = false;
    }
    
    private void Update()
    {
        // 타이머를 업데이트
        timer += Time.deltaTime;

        // 지정한 시간 간격이 되었을 때
        if (timer >= blinkInterval)
        {
            isTextVisible = !isTextVisible; // 텍스트의 가시성을 토글
            startText.enabled = isTextVisible; // 텍스트 활성화/비활성화
            timer = 0f; // 타이머 초기화
        }

        //사용자가 어떤 키든 눌렀을 때
        if (Input.anyKeyDown)
        {
            Destroy(gameObject, 0.7f); // 이 GameObject를 파괴
        }

        // 사용자가 어떤 키든 눌렀을 때
        if (Input.anyKeyDown && !isBlinking)
        {
            isBlinking = true; // 깜빡임 시작
            timer2 = 0f; // 타이머 초기화
            blink.enabled = true; // 이미지 활성화
        }

        // 깜빡이는 동안
        if (isBlinking)
        {
            timer2 += Time.deltaTime; // 타이머 업데이트

            // 지정한 시간 간격이 되었을 때
            if (timer2 >= blinkInterval2)
            {
                isImageVisible = !isImageVisible; // 가시성 토글
                blink.enabled = isImageVisible; // 이미지 활성화/비활성화
                timer2 = 0f; // 타이머 초기화
            }
        }
    }
}

