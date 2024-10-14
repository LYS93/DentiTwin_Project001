using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ending02 : MonoBehaviour
{
    public Text uiText; // UI Text 컴포넌트
    public float fadeDuration = 5f; // 서서히 나타나는 데 걸리는 시간
    private CanvasGroup canvasGroup; // CanvasGroup 컴포넌트
    public ending01 endScript; // 메시지 표시를 관리하는 스크립트

    void Start()
    {
        // CanvasGroup 컴포넌트를 추가하고 초기화
        canvasGroup = uiText.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = uiText.gameObject.AddComponent<CanvasGroup>();
        }
        canvasGroup.alpha = 0f; // 처음에는 완전 투명
    }

    void Update()
    {
        if (transform.position.x <= 11.5f)
        {
            transform.Translate(2 * Time.deltaTime, 0, 0);
        }

        // isLastMessageDisplayed가 true가 되었을 때
        if (endScript.isLastMessageDisplayed)
        {
            // 알파 값을 서서히 증가시켜서 텍스트가 나타나도록 함
            if (canvasGroup.alpha < 1f)
            {
                canvasGroup.alpha += Time.deltaTime / fadeDuration; // 서서히 불투명해짐
            }
        }
    }
}
