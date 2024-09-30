using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class start02 : MonoBehaviour
{
    
    public Text startText; // Inspector���� �Ҵ��� Text ������Ʈ
    public float blinkInterval = 0.5f; // �����̴� ����

    private float timer = 0f; // Ÿ�̸� ����
    private bool isTextVisible = true; // �ؽ�Ʈ ���̴� ����

    private void Awake()
    {
        float savedRestart = PlayerPrefs.GetFloat("Restart");//Restart���� ������

        //����� restart�� 1���� Ŭ��(��, �ڷΰ���� �ٽ� ����ȭ������ ������)
        if (savedRestart >= 1)
        {
            Destroy(gameObject);// �� GameObject�� �ı�
            PlayerPrefs.DeleteKey("Restart");//Restart�� �ʱ�ȭ
        }
    }
    private void Start()
    {
        PlayerPrefs.DeleteAll(); // ��� PlayerPrefs ����
        PlayerPrefs.Save(); // ������� ����
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

        // ����ڰ� � Ű�� ������ ��
        if (Input.anyKeyDown)
        {
            Destroy(gameObject, 0.5f); // �� GameObject�� �ı�
        }
    }
}

