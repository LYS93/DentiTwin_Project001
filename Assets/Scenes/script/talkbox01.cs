using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class talkbox01 : MonoBehaviour
{
    public Text uiText;  // UI Text ������Ʈ�� ����
    public string[] messages = { "��ȭâ �Դϴ�", "���� ��ȭâ �Դϴ�", "������ ��ȭâ �Դϴ�" };  // ����� ���� �޽���
    public float typingSpeed = 0.1f;  // ���ڰ� ��Ÿ���� �ӵ� (��)

    private int currentMessageIndex = 0;  // ���� �޽��� �ε���
    private bool isTyping = false;  // ���� Ÿ���� ������ Ȯ��
    private bool messageCompleted = false;  // �޽����� ��� ��µǾ����� Ȯ��

    void Start()
    {
        StartCoroutine(TypeText());  // ù �޽��� ��� ����
    }

    void Update()
    {
        // �޽����� ��� �Ϸ�� ��, �����̽��ٳ� ���콺 ���� ��ư�� ������ ���� �޽����� �̵�
        if (messageCompleted && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            if (currentMessageIndex < messages.Length - 1)  // ������ �޽����� �ƴ϶��
            {
                currentMessageIndex++;  // �޽��� �ε��� ����
                uiText.text = "";  // �ؽ�Ʈ �ʱ�ȭ
                StartCoroutine(TypeText());  // ���� �޽��� ��� ����
            }
            else
            {
                Debug.Log("��� �޽����� ��µǾ����ϴ�.");  // ��� �޽��� ��� �Ϸ�
            }
        }
    }

    IEnumerator TypeText()
    {
        isTyping = true;
        messageCompleted = false;
        string message = messages[currentMessageIndex];  // ���� �޽����� ������

        // �޽����� �� ���ڸ� �ϳ��� ���
        for (int i = 0; i < message.Length; i++)
        {
            uiText.text += message[i];  // �� ���ھ� �߰�
            yield return new WaitForSeconds(typingSpeed);  // ������ �ð���ŭ ���
        }

        isTyping = false;
        messageCompleted = true;  // �޽��� ��� �Ϸ� ���·� ����
    }

}
