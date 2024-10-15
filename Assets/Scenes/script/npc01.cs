using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class npc01 : MonoBehaviour
{
    public Text npcText; // NPC �Ӹ����� �ؽ�Ʈ
    public GameObject talkScreen; // ��ȭâ
    public GameObject buttonPanel; // ��ư �г� (�̴ϰ��� ���� Ȯ��)
    public Text wrongOrderMessage; // �߸��� ��ȭ ���� �޽��� �ؽ�Ʈ
    private bool playerIn; // �÷��̾� ���� ����

    public static bool isReceptionistTalkCompleted = false;
    public static bool isDoctorTalkCompleted = false;
    public static bool isNurseTalkCompleted = false;

    public string npcRole; // NPC�� ���� ("reception", "doctor", "nurse")

    private bool showWrongOrderMessage; // �߸��� �޽����� ǥ������ ����

    void Start()
    {
        npcText.enabled = false;
        talkScreen.SetActive(false);
        buttonPanel.SetActive(false); // ó������ ��ư �г��� ��Ȱ��ȭ
        wrongOrderMessage.enabled = false; // �߸��� ��ȭ ���� �޽��� ��Ȱ��ȭ

        // �� ���� �� ��ȭ ���� ���� �ʱ�ȭ
        isReceptionistTalkCompleted = false;
        isDoctorTalkCompleted = false;
        isNurseTalkCompleted = false;
    }

    void Update()
    {
        if (playerIn)
        {
            // ��ȭ ȭ�鿡 �޽��� ǥ��
            if (talkScreen.activeSelf)
            {
                npcText.text = "'�����̽���'�� ���� ��ȭ�� �Ѱ��ּ���\n��ȭ�� �׸� �Ͻ÷��� 'ESC'�� �����ּ���";
            }
            else
            {
                npcText.text = "��ȭ�� �Ͻ÷��� '�����̽���'�� �����ּ���";
            }

            // ��ȭ�� �����Ϸ��� ���
            if (Input.GetKeyDown(KeyCode.Space) && !talkScreen.activeSelf)
            {
                if (npcRole == "reception")
                {
                    talkScreen.SetActive(true);
                }
                else if (npcRole == "doctor" && isReceptionistTalkCompleted)
                {
                    talkScreen.SetActive(true);
                }
                else if (npcRole == "nurse" && isDoctorTalkCompleted)
                {
                    talkScreen.SetActive(true);
                }
                else
                {
                    showWrongOrderMessage = true; // �߸��� ��ȭ �õ�
                    wrongOrderMessage.text = "������-�ǻ�-��ȣ�� ������ ��ȭ�� ���ּ���";
                    wrongOrderMessage.enabled = true; // �߸��� ��ȭ ���� �޽��� Ȱ��ȭ
                }
            }

            // ��ȭ ����
            if (Input.GetKeyDown(KeyCode.Escape) && talkScreen.activeSelf)
            {
                talkScreen.SetActive(false);

                // ��ȭ �Ϸ� ���� ����
                if (npcRole == "reception")
                {
                    isReceptionistTalkCompleted = true;
                }
                else if (npcRole == "doctor")
                {
                    isDoctorTalkCompleted = true;
                }
                else if (npcRole == "nurse")
                {
                    isNurseTalkCompleted = true;

                    // ��ȣ�� ��ȭ�� ������ ��ư �г��� Ȱ��ȭ
                    buttonPanel.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            npcText.enabled = true;
            playerIn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            npcText.enabled = false;
            playerIn = false;
            talkScreen.SetActive(false);
            wrongOrderMessage.enabled = false; // ������ ����� �߸��� ��ȭ ���� �޽��� ��Ȱ��ȭ
            buttonPanel.SetActive(false); // NPC�� ������ ��ư �гε� ��Ȱ��ȭ
        }
    }

    // 1. �̴ϰ������� �Ѿ�� ��ư �޼���
    public void StartMiniGame()
    {
        SceneManager.LoadScene("MiniGameScene"); // "MiniGameScene"�� �̴ϰ��� ���� �̸����� ����
    }

    // 2. ��� ��ư �޼���
    public void CancelMiniGame()
    {
        buttonPanel.SetActive(false); // ��ư �г� ��Ȱ��ȭ
    }
}
