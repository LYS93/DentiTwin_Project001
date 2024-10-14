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

    void Start()
    {
        // CanvasGroup ������Ʈ�� �߰��ϰ� �ʱ�ȭ
        canvasGroup = uiText.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = uiText.gameObject.AddComponent<CanvasGroup>();
        }
        canvasGroup.alpha = 0f; // ó������ ���� ����
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
            // ���� ���� ������ �������Ѽ� �ؽ�Ʈ�� ��Ÿ������ ��
            if (canvasGroup.alpha < 1f)
            {
                canvasGroup.alpha += Time.deltaTime / fadeDuration; // ������ ����������
            }
        }
    }
}
