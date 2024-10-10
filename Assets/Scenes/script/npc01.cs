using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npc01 : MonoBehaviour
{
    public Text npcText; // NPC �Ӹ����� �ؽ�Ʈ
    public GameObject talkScreen; // ��ȭâ
    private bool playerIn; // �÷��̾� ���� ����
    public Text wrongOrderMessage; // �߸��� ��ȭ ���� �޽��� �ؽ�Ʈ

    // ��ȭ ���� ��� ���� ���� ������
    public static bool isReceptionistTalkCompleted = false; // ������ NPC ��ȭ �Ϸ� ����
    public static bool isDoctorTalkCompleted = false; // �ǻ� NPC ��ȭ �Ϸ� ����
    public static bool isNurseTalkCompleted = false; // ��ȣ�� NPC ��ȭ �Ϸ� ����

    public string npcRole; // NPC�� ���� ("reception", "doctor", "nurse")

    private bool showWrongOrderMessage; // �߸��� �޽����� ǥ������ ����

    void Start()
    {
        npcText.enabled = false;
        talkScreen.SetActive(false);
        wrongOrderMessage.enabled = false; // �޽��� ó���� ��Ȱ��ȭ
    }

    void Update()
    {
        if (playerIn)
        {
            // ��ȭ ȭ�鿡 �޽��� ǥ��
            if (talkScreen.activeSelf)
            {
                npcText.text = "��ȭ�� �����Ϸ��� 'ESC'�� �����ּ���";
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
                    wrongOrderMessage.text = "������ �´� NPC�� ���� ��ȭ�ϼ���.";
                    wrongOrderMessage.enabled = true; // �޽��� Ȱ��ȭ
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
            talkScreen.SetActive(false); // ������ ��� �� ��ȭâ �ݱ�
            wrongOrderMessage.enabled = false; // NPC�� ���� �� �߸��� ��ȭ �޽��� ��Ȱ��ȭ
        }
    }
}
