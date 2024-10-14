using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ending03 : MonoBehaviour
{
    public GameObject[] backgrounds; // 3���� ��� ��������Ʈ
    public float speed = 2f; // �̵� �ӵ�
    public float customWidth = 20.48f; // ����� ���� �ʺ� (��ġ�� ���� ����)
    public ending01 endScript;

    void Start()
    {
        // ����� �ʱ� ��ġ�� ��ġ
        for (int i = 0; i < backgrounds.Length; i++)
        {
            Vector3 newPos = new Vector3(i * customWidth, backgrounds[i].transform.position.y, backgrounds[i].transform.position.z);
            backgrounds[i].transform.position = newPos;
        }
    }

    void Update()
    {
        if (!endScript.isLastMessageDisplayed)
        {
            for (int i = 0; i < backgrounds.Length; i++)
            {
                // �� ��� ��������Ʈ�� �������� �̵�
                backgrounds[i].transform.position += Vector3.left * speed * Time.deltaTime;

                // ����� ȭ�� ���� ������ ������, �ٽ� ������ ������ �̵���Ŵ
                if (backgrounds[i].transform.position.x <= -customWidth)
                {
                    // ������ ����� ������ ���� ���� �ʺ�ŭ �̾ ��ġ
                    Vector3 newPos = backgrounds[i].transform.position;
                    newPos.x += customWidth * backgrounds.Length; // ���� �ʺ�ŭ �̵�
                    backgrounds[i].transform.position = newPos;
                }
            }
        }
    }
}
