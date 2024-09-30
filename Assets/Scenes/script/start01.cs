using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class start01 : MonoBehaviour
{
    public GameObject optionsPanel; // �ɼ� �г�
    public Button[] buttons; //�ɼ� �г� �̿��� ��ư
    float restart;//�ٽ� �����Ҷ�
    public GameObject startScreen;//���۽�ũ��
    
    void Start()
    {
        // ���� �� �ɼ� �г��� ��Ȱ��ȭ
        optionsPanel.SetActive(false);
        
        //���۽�ũ���� ������
        if(startScreen == null)
        {
            PlayerPrefs.DeleteKey("Restart");//Restart�� �ʱ�ȭ
        }

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
        //����ۿ��� ���۽�ũ���� �ȶߵ���
        restart += 1f;
        PlayerPrefs.SetFloat("Restart", restart);
    }
    public void Quit()
    {
        //��������
        Application.Quit();
        
        PlayerPrefs.DeleteAll(); // ��� PlayerPrefs ����
        PlayerPrefs.Save(); // ������� ����

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // �����Ϳ����� �÷��� ��� ����
#endif
    }

}
