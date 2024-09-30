using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class start02 : MonoBehaviour
{
    
    public Text myText; // Inspector에서 할당할 Text 컴포넌트
    public float blinkInterval = 0.5f; // 깜빡이는 간격

    private float timer = 0f; // 타이머 변수
    private bool isTextVisible = true; // 텍스트 가시성 상태

    private void Update()
    {
        // 타이머를 업데이트
        timer += Time.deltaTime;

        // 지정한 시간 간격이 되었을 때
        if (timer >= blinkInterval)
        {
            isTextVisible = !isTextVisible; // 텍스트의 가시성을 토글
            myText.enabled = isTextVisible; // 텍스트 활성화/비활성화
            timer = 0f; // 타이머 초기화
        }

        // 사용자가 어떤 키든 눌렀을 때
        if (Input.anyKeyDown)
        {
            Destroy(gameObject, 0.5f); // 이 GameObject를 파괴
        }
    }
}

