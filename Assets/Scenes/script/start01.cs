using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class start01 : MonoBehaviour
{
    public GameObject optionsPanel; // �ɼ� �г�
    public Button[] buttons; //�ɼ� �г� �̿��� ��ư

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        optionsPanel = GameObject.Find("Canvas_sound");
        // ���� �� �ɼ� �г��� ��Ȱ��ȭ
        optionsPanel.SetActive(false);

        
    }
    void Update()
    {
        // �ɼ� �г��� Ȱ��ȭ ���¿� ���� ��ư ���� ����
        bool isActive = optionsPanel.activeSelf;

        // ��ư �迭�� ��ȸ�ϸ� interactable �Ӽ� ����
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = !isActive; // �ɼ� �г��� Ȱ��ȭ�Ǹ� ��ư ��Ȱ��ȭ
        }
    }
    public void OnOptions()
    {
        // �ɼ� �г��� Ȱ��ȭ
        optionsPanel.SetActive(true);
    }

    public void OffOptions()
    {
        // �ɼ� �г��� ��Ȱ��ȭ
        optionsPanel.SetActive(false);
    }
    public void doc_scene()
    {
        // �ǻ� ������ ��ȯ
        SceneManager.LoadScene("DoctorScene");
    }
    public void pat_scene()
    {
        // ȯ�� ������ ��ȯ
        SceneManager.LoadScene("PatientScene");
    }
    public void back()
    {
        //���� ������ ��ȯ
        SceneManager.LoadScene("StartScene");
    }
    public void Quit()
    {
        //��������
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // �����Ϳ����� �÷��� ��� ����
#endif
    }

}
