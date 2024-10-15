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
    public Canvas newCanvas; // 새롭게 나타날 Canvas
    private CanvasGroup newCanvasGroup; // 새 Canvas의 CanvasGroup
    private bool isNewCanvasFadingIn = false; // 새 Canvas의 페이드 상태 체크
    private bool isGameEnding = false; // 게임 종료 상태 체크

    void Start()
    {
        // 기존 CanvasGroup 컴포넌트를 추가하고 초기화
        canvasGroup = uiText.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = uiText.gameObject.AddComponent<CanvasGroup>();
        }
        canvasGroup.alpha = 0f; // 처음에는 완전 투명

        // 새 Canvas에 대한 CanvasGroup 초기화
        newCanvasGroup = newCanvas.GetComponent<CanvasGroup>();
        if (newCanvasGroup == null)
        {
            newCanvasGroup = newCanvas.gameObject.AddComponent<CanvasGroup>();
        }
        newCanvasGroup.alpha = 0f; // 새 Canvas는 처음에 투명하게 설정
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
            // 기존 텍스트의 알파 값을 서서히 증가시켜서 텍스트가 나타나도록 함
            if (canvasGroup.alpha < 1f)
            {
                canvasGroup.alpha += Time.deltaTime / fadeDuration; // 서서히 불투명해짐
            }
            else if (!isNewCanvasFadingIn)
            {
                // 기존 텍스트가 완전히 나타난 후 새 Canvas가 서서히 나타나기 시작
                isNewCanvasFadingIn = true;
                uiText.enabled = false;
            }
        }

        // 새 Canvas가 서서히 나타나도록
        if (isNewCanvasFadingIn && newCanvasGroup.alpha < 1f)
        {
            newCanvasGroup.alpha += Time.deltaTime / fadeDuration; // 서서히 불투명해짐
        }
        else if (isNewCanvasFadingIn && newCanvasGroup.alpha >= 1f && !isGameEnding)
        {
            // 새 Canvas가 완전히 나타난 후 5초 후에 게임 종료
            isGameEnding = true;
            Invoke("QuitGame", 5f); // 5초 후에 게임 종료 호출
        }
    }

    void QuitGame()
    {
        // 게임 종료
        Application.Quit();
        // 에디터에서 테스트할 때는 종료가 안 되므로 아래 코드로 대체 가능
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
