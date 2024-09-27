using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start01 : MonoBehaviour
{
    public GameObject optionsPanel; // �ɼ� �г�

    void Start()
    {
        // ���� �� �ɼ� �г��� ��Ȱ��ȭ
        optionsPanel.SetActive(false);
    }

    public void OnOptionsButtonClicked()
    {
        // �ɼ� �г��� Ȱ��ȭ
        optionsPanel.SetActive(true);
    }

    public void OnBackButtonClicked()
    {
        // �ɼ� �г��� ��Ȱ��ȭ
        optionsPanel.SetActive(false);
    }
}
