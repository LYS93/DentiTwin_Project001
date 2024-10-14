using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class start01 : MonoBehaviour
{
    public GameObject optionsPanel; // 옵션 패널
    public Button[] buttons; // 버튼 배열
    public GameObject startScreen; // 시작 스크린
    public GameObject[] npcTalkScreens; // 세 명의 NPC 대화창 배열
    
    private void Awake()
    {
        Application.targetFrameRate = 60;
        optionsPanel.SetActive(false);
    }

    void Start()
    {
        // 시작 스크린이 없을 때 Restart 키 초기화
        if (startScreen == null)
        {
            PlayerPrefs.DeleteKey("Restart");
        }
    }

    void Update()
    {
        bool isAnyTalkScreenActive = false;

        // 세 NPC의 대화창이 열려 있는지 확인
        for (int i = 0; i < npcTalkScreens.Length; i++)
        {
            if (npcTalkScreens[i].activeSelf)
            {
                isAnyTalkScreenActive = true;
                break;
            }
        }

        // 옵션 패널이나 대화창이 열려 있을 때 버튼 비활성화
        bool isOptionsActive = optionsPanel.activeSelf;

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = !isOptionsActive && !isAnyTalkScreenActive;
        }
    }

    public void OnOptions()
    {
        optionsPanel.SetActive(true);
    }

    public void OffOptions()
    {
        optionsPanel.SetActive(false);
    }

    public void doc_scene()
    {
        SceneManager.LoadScene("DoctorScene");
    }

    public void pat_scene()
    {
        SceneManager.LoadScene("PatientScene");
    }

    public void back()
    {
        SceneManager.LoadScene("StartScene");
        PlayerPrefs.SetFloat("Restart", PlayerPrefs.GetFloat("Restart", 0) + 1f);
    }

    public void Quit()
    {
        Application.Quit();
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
