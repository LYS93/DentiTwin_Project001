using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class start01 : MonoBehaviour
{
    public GameObject optionsPanel; // �ɼ� �г�
    public Button[] buttons; // ��ư �迭
    public GameObject startScreen; // ���� ��ũ��
    public GameObject[] npcTalkScreens; // �� ���� NPC ��ȭâ �迭
    
    private void Awake()
    {
        Application.targetFrameRate = 60;
        optionsPanel.SetActive(false);
    }

    void Start()
    {
        // ���� ��ũ���� ���� �� Restart Ű �ʱ�ȭ
        if (startScreen == null)
        {
            PlayerPrefs.DeleteKey("Restart");
        }
    }

    void Update()
    {
        bool isAnyTalkScreenActive = false;

        // �� NPC�� ��ȭâ�� ���� �ִ��� Ȯ��
        for (int i = 0; i < npcTalkScreens.Length; i++)
        {
            if (npcTalkScreens[i].activeSelf)
            {
                isAnyTalkScreenActive = true;
                break;
            }
        }

        // �ɼ� �г��̳� ��ȭâ�� ���� ���� �� ��ư ��Ȱ��ȭ
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
