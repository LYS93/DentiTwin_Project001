using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start02 : MonoBehaviour
{
    private void Awake()
    {
        // �� ������Ʈ�� �ı����� �ʵ��� ����
        DontDestroyOnLoad(gameObject);
    }

}
