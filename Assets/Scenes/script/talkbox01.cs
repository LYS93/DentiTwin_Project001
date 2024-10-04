using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class talkbox01 : MonoBehaviour
{
    public Text uiText;  // UI Text 컴포넌트를 연결
    public string[] messages = { "대화창 입니다", "다음 대화창 입니다", "마지막 대화창 입니다" };  // 출력할 여러 메시지
    public float typingSpeed = 0.1f;  // 글자가 나타나는 속도 (초)

    private int currentMessageIndex = 0;  // 현재 메시지 인덱스
    private bool isTyping = false;  // 현재 타이핑 중인지 확인
    private bool messageCompleted = false;  // 메시지가 모두 출력되었는지 확인

    void Start()
    {
        StartCoroutine(TypeText());  // 첫 메시지 출력 시작
    }

    void Update()
    {
        // 메시지가 출력 완료된 후, 스페이스바나 마우스 왼쪽 버튼을 누르면 다음 메시지로 이동
        if (messageCompleted && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            if (currentMessageIndex < messages.Length - 1)  // 마지막 메시지가 아니라면
            {
                currentMessageIndex++;  // 메시지 인덱스 증가
                uiText.text = "";  // 텍스트 초기화
                StartCoroutine(TypeText());  // 다음 메시지 출력 시작
            }
            else
            {
                Debug.Log("모든 메시지가 출력되었습니다.");  // 모든 메시지 출력 완료
            }
        }
    }

    IEnumerator TypeText()
    {
        isTyping = true;
        messageCompleted = false;
        string message = messages[currentMessageIndex];  // 현재 메시지를 가져옴

        // 메시지의 각 문자를 하나씩 출력
        for (int i = 0; i < message.Length; i++)
        {
            uiText.text += message[i];  // 한 글자씩 추가
            yield return new WaitForSeconds(typingSpeed);  // 설정된 시간만큼 대기
        }

        isTyping = false;
        messageCompleted = true;  // 메시지 출력 완료 상태로 변경
    }

}
