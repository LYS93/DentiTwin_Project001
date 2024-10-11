using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ending01 : MonoBehaviour
{
    public Text uiText;  // 출력할 UI 텍스트 컴포넌트
    [TextArea]
    public string message;  // 출력할 문자열
    public float typingSpeed = 0.1f;  // 글자 나타나는 속도 (초 단위)

    private void Start()
    {
        // 초기화: 텍스트를 비워둠
        uiText.text = "";

        // 코루틴 시작: 글자를 한 번에 하나씩 출력
        StartCoroutine(ShowText());
    }

    // 코루틴: 한 글자씩 텍스트를 출력하는 함수
    IEnumerator ShowText()
    {
        foreach (char letter in message)
        {
            uiText.text += letter;  // 한 글자씩 추가
            yield return new WaitForSeconds(typingSpeed);  // 지정된 시간만큼 대기
        }

        // 모든 글자가 출력된 후 10초 대기
        yield return new WaitForSeconds(10f);

        // 게임 종료
        Application.Quit();  // 게임 종료
    }
}
