using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class start02 : MonoBehaviour
{
    
    public Text startText; // ���۽�ũ�� �۾�(������ �����Ϸ��� �ƹ�Ű�� ��������)
    float blinkInterval = 0.5f; // �����̴� ����
    private float timer = 0f; // Ÿ�̸� ����
    private bool isTextVisible = true; // �ؽ�Ʈ ���̴� ����

    public Image blink;
    private float timer2 = 0f; // Ÿ�̸� ����2
    bool isImageVisible = false; // ���꽺ũ�� ���̴� ����
    float blinkInterval2 = 0.08f; // �����̴� ����2
    private bool isBlinking = false; //�����̴� ����


    private void Awake()
    {
        float savedRestart = PlayerPrefs.GetFloat("Restart");//Restart���� ������

        //����� restart�� 1���� Ŭ��(��, �ڷΰ���� �ٽ� ����ȭ������ ������)
        if (savedRestart >= 1)
        {
            Destroy(gameObject);// �� GameObject�� �ı�
            PlayerPrefs.DeleteKey("Restart");//Restart�� �ʱ�ȭ
        }
        else
        {
            PlayerPrefs.DeleteAll(); // ��� PlayerPrefs ����
            PlayerPrefs.Save(); // ������� ����
        }
        
        blink.enabled = false;
    }
    
    private void Update()
    {
        // Ÿ�̸Ӹ� ������Ʈ
        timer += Time.deltaTime;

        // ������ �ð� ������ �Ǿ��� ��
        if (timer >= blinkInterval)
        {
            isTextVisible = !isTextVisible; // �ؽ�Ʈ�� ���ü��� ���
            startText.enabled = isTextVisible; // �ؽ�Ʈ Ȱ��ȭ/��Ȱ��ȭ
            timer = 0f; // Ÿ�̸� �ʱ�ȭ
        }

        //����ڰ� � Ű�� ������ ��
        if (Input.anyKeyDown)
        {
            Destroy(gameObject, 0.7f); // �� GameObject�� �ı�
        }

        // ����ڰ� � Ű�� ������ ��
        if (Input.anyKeyDown && !isBlinking)
        {
            isBlinking = true; // ������ ����
            timer2 = 0f; // Ÿ�̸� �ʱ�ȭ
            blink.enabled = true; // �̹��� Ȱ��ȭ
        }

        // �����̴� ����
        if (isBlinking)
        {
            timer2 += Time.deltaTime; // Ÿ�̸� ������Ʈ

            // ������ �ð� ������ �Ǿ��� ��
            if (timer2 >= blinkInterval2)
            {
                isImageVisible = !isImageVisible; // ���ü� ���
                blink.enabled = isImageVisible; // �̹��� Ȱ��ȭ/��Ȱ��ȭ
                timer2 = 0f; // Ÿ�̸� �ʱ�ȭ
            }
        }
    }
}

