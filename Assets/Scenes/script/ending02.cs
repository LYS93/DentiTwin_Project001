using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ending02 : MonoBehaviour
{
    public Text uiText; // UI Text ������Ʈ
    public float fadeDuration = 5f; // ������ ��Ÿ���� �� �ɸ��� �ð�
    private CanvasGroup canvasGroup; // CanvasGroup ������Ʈ
    public ending01 endScript; // �޽��� ǥ�ø� �����ϴ� ��ũ��Ʈ
    public Canvas newCanvas; // ���Ӱ� ��Ÿ�� Canvas
    private CanvasGroup newCanvasGroup; // �� Canvas�� CanvasGroup
    private bool isNewCanvasFadingIn = false; // �� Canvas�� ���̵� ���� üũ
    private bool isGameEnding = false; // ���� ���� ���� üũ

    void Start()
    {
        // ���� CanvasGroup ������Ʈ�� �߰��ϰ� �ʱ�ȭ
        canvasGroup = uiText.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = uiText.gameObject.AddComponent<CanvasGroup>();
        }
        canvasGroup.alpha = 0f; // ó������ ���� ����

        // �� Canvas�� ���� CanvasGroup �ʱ�ȭ
        newCanvasGroup = newCanvas.GetComponent<CanvasGroup>();
        if (newCanvasGroup == null)
        {
            newCanvasGroup = newCanvas.gameObject.AddComponent<CanvasGroup>();
        }
        newCanvasGroup.alpha = 0f; // �� Canvas�� ó���� �����ϰ� ����
    }

    void Update()
    {
        if (transform.position.x <= 11.5f)
        {
            transform.Translate(2 * Time.deltaTime, 0, 0);
        }

        // isLastMessageDisplayed�� true�� �Ǿ��� ��
        if (endScript.isLastMessageDisplayed)
        {
            // ���� �ؽ�Ʈ�� ���� ���� ������ �������Ѽ� �ؽ�Ʈ�� ��Ÿ������ ��
            if (canvasGroup.alpha < 1f)
            {
                canvasGroup.alpha += Time.deltaTime / fadeDuration; // ������ ����������
            }
            else if (!isNewCanvasFadingIn)
            {
                // ���� �ؽ�Ʈ�� ������ ��Ÿ�� �� �� Canvas�� ������ ��Ÿ���� ����
                isNewCanvasFadingIn = true;
                uiText.enabled = false;
            }
        }

        // �� Canvas�� ������ ��Ÿ������
        if (isNewCanvasFadingIn && newCanvasGroup.alpha < 1f)
        {
            newCanvasGroup.alpha += Time.deltaTime / fadeDuration; // ������ ����������
        }
        else if (isNewCanvasFadingIn && newCanvasGroup.alpha >= 1f && !isGameEnding)
        {
            // �� Canvas�� ������ ��Ÿ�� �� 5�� �Ŀ� ���� ����
            isGameEnding = true;
            Invoke("QuitGame", 5f); // 5�� �Ŀ� ���� ���� ȣ��
        }
    }

    void QuitGame()
    {
        // ���� ����
        Application.Quit();
        // �����Ϳ��� �׽�Ʈ�� ���� ���ᰡ �� �ǹǷ� �Ʒ� �ڵ�� ��ü ����
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
