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
    public GameObject dialogCanvas;  // ��ȭâ�� �ִ� ĵ����

    private bool dialogJustOpened = false;  // ��ȭâ�� ��� ���ȴ��� Ȯ���ϴ� ����
    private Coroutine typingCoroutine;  // ���� ���� ���� �ڷ�ƾ�� �����ϴ� ����

    void Start()
    {
        //dialogCanvas.SetActive(false);  // ó���� ��ȭâ�� ��Ȱ��ȭ
    }

    void Update()
    {
        // ��ȭâ�� ������ ���� ����
        if (dialogCanvas.activeSelf && !dialogJustOpened)
        {
            dialogJustOpened = true;  // ��ȭâ�� ��� ���ȴٰ� ǥ��
            currentMessageIndex = 0;  // ��ȭ �ε����� ó������ ����
            messageCompleted = false;  // �޽��� �Ϸ� ���� �ʱ�ȭ
            isTyping = false;  // Ÿ���� ���� �ʱ�ȭ
            uiText.text = "";  // ��ȭâ �ؽ�Ʈ �ʱ�ȭ

            // ������ ���� ���� �ڷ�ƾ�� �ִٸ� �ߴ�
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
            }

            // ���ο� �ڷ�ƾ ����
            typingCoroutine = StartCoroutine(TypeText());  // �޽��� ��� ����
        }

        // �޽����� ��� �Ϸ�� ��, �����̽��ٳ� ���콺 ���� ��ư�� ������ ���� �޽����� �̵�
        if (messageCompleted && !isTyping && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            if (currentMessageIndex < messages.Length - 1)  // ������ �޽����� �ƴ϶��
            {
                currentMessageIndex++;  // �޽��� �ε��� ����
                uiText.text = "";  // �ؽ�Ʈ �ʱ�ȭ
                messageCompleted = false;

                // ������ ���� ���� �ڷ�ƾ�� �ִٸ� �ߴ�
                if (typingCoroutine != null)
                {
                    StopCoroutine(typingCoroutine);
                }

                // ���ο� �ڷ�ƾ ����
                typingCoroutine = StartCoroutine(TypeText());  // ���� �޽��� ��� ����
            }
            //else
            //{
            //    Debug.Log("��� �޽����� ��µǾ����ϴ�.");  // ��� �޽��� ��� �Ϸ�
            //}
        }

        // ��ȭâ�� ������ �ʱ� ���·� �ǵ���
        if (!dialogCanvas.activeSelf)
        {
            dialogJustOpened = false;  // ��ȭâ�� �����ٰ� ǥ��
            uiText.text = "";  // ��ȭâ �ؽ�Ʈ �ʱ�ȭ
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
            yield return new WaitForSeconds(Mathf.Max(typingSpeed, 0.05f));  // �ּ� ��� �ð��� 0.05�ʷ� ����
        }

        isTyping = false;
        messageCompleted = true;  // �޽��� ��� �Ϸ� ���·� ����
    }
}
