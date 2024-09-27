using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start01 : MonoBehaviour
{
    public GameObject optionsPanel; // 옵션 패널

    void Start()
    {
        // 시작 시 옵션 패널을 비활성화
        optionsPanel.SetActive(false);
    }

    public void OnOptionsButtonClicked()
    {
        // 옵션 패널을 활성화
        optionsPanel.SetActive(true);
    }

    public void OnBackButtonClicked()
    {
        // 옵션 패널을 비활성화
        optionsPanel.SetActive(false);
    }
}
