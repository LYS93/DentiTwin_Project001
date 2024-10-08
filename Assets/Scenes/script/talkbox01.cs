using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class talkbox01 : MonoBehaviour
{
    public Text uiText;  // UI Text 컴포넌트를 연결
    [TextArea]
    public string[] messages; // 출력할 여러 메시지
    public float typingSpeed = 0.1f;  // 글자가 나타나는 속도 (초)

    private int currentMessageIndex = 0;  // 현재 메시지 인덱스
    private bool isTyping = false;  // 현재 타이핑 중인지 확인
    private bool messageCompleted = false;  // 메시지가 모두 출력되었는지 확인
    public GameObject dialogCanvas;  // 대화창이 있는 캔버스

    private bool dialogJustOpened = false;  // 대화창이 방금 열렸는지 확인하는 변수
    private Coroutine typingCoroutine;  // 현재 실행 중인 코루틴을 저장하는 변수

    void Start()
    {
        // dialogCanvas.SetActive(false);  // 처음엔 대화창을 비활성화
    }

    void Update()
    {
        // 대화창이 열리는 순간 감지
        if (dialogCanvas.activeSelf && !dialogJustOpened)
        {
            dialogJustOpened = true;  // 대화창이 방금 열렸다고 표시
            currentMessageIndex = 0;  // 대화 인덱스를 처음으로 설정
            messageCompleted = false;  // 메시지 완료 상태 초기화
            isTyping = false;  // 타이핑 상태 초기화
            uiText.text = "";  // 대화창 텍스트 초기화

            // 기존에 실행 중인 코루틴이 있다면 중단
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
            }

            // 새로운 코루틴 실행
            typingCoroutine = StartCoroutine(TypeText());  // 메시지 출력 시작
        }

        // 메시지가 출력 완료된 후, 스페이스바나 마우스 왼쪽 버튼을 누르면 다음 메시지로 이동
        if (messageCompleted && !isTyping && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            if (currentMessageIndex < messages.Length - 1)  // 마지막 메시지가 아니라면
            {
                currentMessageIndex++;  // 메시지 인덱스 증가
                uiText.text = "";  // 텍스트 초기화
                messageCompleted = false;

                // 기존에 실행 중인 코루틴이 있다면 중단
                if (typingCoroutine != null)
                {
                    StopCoroutine(typingCoroutine);
                }

                // 새로운 코루틴 실행
                typingCoroutine = StartCoroutine(TypeText());  // 다음 메시지 출력 시작
            }
            // else
            // {
            //     Debug.Log("모든 메시지가 출력되었습니다.");  // 모든 메시지 출력 완료
            // }
        }

        // 대화창이 닫히면 초기 상태로 되돌림
        if (!dialogCanvas.activeSelf)
        {
            dialogJustOpened = false;  // 대화창이 닫혔다고 표시
            uiText.text = "";  // 대화창 텍스트 초기화
        }
    }

    IEnumerator TypeText()
    {
        isTyping = true;
        messageCompleted = false;
        string message = messages[currentMessageIndex];  // 현재 메시지를 가져옴
        uiText.text = "";  // 대화창 텍스트 초기화

        int charIndex = 0;
        while (charIndex < message.Length)
        {
            if (message[charIndex] == '<')  // 태그의 시작 부분이면
            {
                // 태그와 그 안의 내용을 한꺼번에 처리
                int tagEndIndex = message.IndexOf('>', charIndex);  // 태그의 끝을 찾음
                if (tagEndIndex != -1)
                {
                    // 태그 닫힌 부분 이후에 나오는 텍스트가 있는지 확인
                    int closeTagIndex = message.IndexOf("</color>", tagEndIndex);
                    if (closeTagIndex != -1)
                    {
                        // 태그와 그 안의 텍스트를 한 번에 출력
                        string coloredText = message.Substring(charIndex, closeTagIndex + 8 - charIndex);  // </color> 포함
                        uiText.text += coloredText;
                        charIndex = closeTagIndex + 8;  // </color> 이후로 인덱스 이동
                    }
                    else
                    {
                        // 잘못된 태그일 경우 안전하게 처리
                        charIndex = tagEndIndex + 1;
                    }
                }
            }
            else
            {
                // 태그가 아닌 경우 한 글자씩 출력
                uiText.text += message[charIndex];
                charIndex++;
                yield return new WaitForSeconds(Mathf.Max(typingSpeed, 0.05f));  // 최소 대기 시간을 0.05초로 설정
            }
        }

        isTyping = false;
        messageCompleted = true;  // 메시지 출력 완료 상태로 변경
    }
}
