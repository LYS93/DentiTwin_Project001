using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ending01 : MonoBehaviour
{
    public RectTransform textTransform; // UI �ؽ�Ʈ�� RectTransform
    public Text uiText; // UI Text ������Ʈ
    public float speed = 300f; // �ؽ�Ʈ�� �����̴� �ӵ�

    [TextArea] // �ν����Ϳ��� ���� ���� �ؽ�Ʈ�� �Է��� �� �ְ� ����
    public string[] messages; // ǥ���� �ؽ�Ʈ �迭
    private int currentMessageIndex = 0; // ���� ǥ�� ���� �ؽ�Ʈ �ε���

    public bool isLastMessageDisplayed = false; // ������ �޽��� ǥ�� ����

    void Start()
    {
        // ó�� �ؽ�Ʈ ����
        uiText.text = messages[currentMessageIndex];
    }

    void Update()
    {
        // ������ �޽����� ǥ�õ� ���, �ؽ�Ʈ�� �� �̻� �̵����� ����
        if (isLastMessageDisplayed)
        {
            return; // Update �޼��� ����
        }

        // ���� ��ġ���� �������� �̵�
        textTransform.anchoredPosition += Vector2.left * speed * Time.deltaTime;

        // �ؽ�Ʈ�� ȭ�� ���� ������ ������ ��
        if (textTransform.anchoredPosition.x < -Screen.width * 0.85f)
        {
            // ���������� �ٽ� ������
            textTransform.anchoredPosition = new Vector2(Screen.width * 0.85f, textTransform.anchoredPosition.y);

            // ���� �ؽ�Ʈ�� ����
            currentMessageIndex++;

            // ������ �޽����� ����� ���
            if (currentMessageIndex >= messages.Length)
            {
                isLastMessageDisplayed = true; // bool ���� true�� ����
                uiText.text = ""; // �ؽ�Ʈ�� �� ���ڿ��� �����Ͽ� �� �̻� ǥ������ ����
            }
            else
            {
                uiText.text = messages[currentMessageIndex]; // ���� �޽��� ����
            }
        }
    }
}
