using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ending01 : MonoBehaviour
{
    public Text uiText;  // ����� UI �ؽ�Ʈ ������Ʈ
    [TextArea]
    public string message;  // ����� ���ڿ�
    public float typingSpeed = 0.1f;  // ���� ��Ÿ���� �ӵ� (�� ����)

    private void Start()
    {
        // �ʱ�ȭ: �ؽ�Ʈ�� �����
        uiText.text = "";

        // �ڷ�ƾ ����: ���ڸ� �� ���� �ϳ��� ���
        StartCoroutine(ShowText());
    }

    // �ڷ�ƾ: �� ���ھ� �ؽ�Ʈ�� ����ϴ� �Լ�
    IEnumerator ShowText()
    {
        foreach (char letter in message)
        {
            uiText.text += letter;  // �� ���ھ� �߰�
            yield return new WaitForSeconds(typingSpeed);  // ������ �ð���ŭ ���
        }

        // ��� ���ڰ� ��µ� �� 10�� ���
        yield return new WaitForSeconds(10f);

        // ���� ����
        Application.Quit();  // ���� ����
    }
}
