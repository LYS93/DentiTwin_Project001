using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ending01 : MonoBehaviour
{
    public RectTransform textTransform; // UI 텍스트의 RectTransform
    public Text uiText; // UI Text 컴포넌트
    public float speed = 300f; // 텍스트가 움직이는 속도

    [TextArea] // 인스펙터에서 여러 줄의 텍스트를 입력할 수 있게 설정
    public string[] messages; // 표시할 텍스트 배열
    private int currentMessageIndex = 0; // 현재 표시 중인 텍스트 인덱스

    public bool isLastMessageDisplayed = false; // 마지막 메시지 표시 여부

    void Start()
    {
        // 처음 텍스트 설정
        uiText.text = messages[currentMessageIndex];
    }

    void Update()
    {
        // 마지막 메시지가 표시된 경우, 텍스트를 더 이상 이동하지 않음
        if (isLastMessageDisplayed)
        {
            return; // Update 메서드 종료
        }

        // 현재 위치에서 왼쪽으로 이동
        textTransform.anchoredPosition += Vector2.left * speed * Time.deltaTime;

        // 텍스트가 화면 왼쪽 밖으로 나갔을 때
        if (textTransform.anchoredPosition.x < -Screen.width * 0.85f)
        {
            // 오른쪽으로 다시 보내기
            textTransform.anchoredPosition = new Vector2(Screen.width * 0.85f, textTransform.anchoredPosition.y);

            // 다음 텍스트로 변경
            currentMessageIndex++;

            // 마지막 메시지를 출력한 경우
            if (currentMessageIndex >= messages.Length)
            {
                isLastMessageDisplayed = true; // bool 값을 true로 변경
                uiText.text = ""; // 텍스트를 빈 문자열로 설정하여 더 이상 표시하지 않음
            }
            else
            {
                uiText.text = messages[currentMessageIndex]; // 다음 메시지 설정
            }
        }
    }
}
