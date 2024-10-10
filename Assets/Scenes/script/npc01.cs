using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npc01 : MonoBehaviour
{
    public Text npcText; // NPC �Ӹ����� �ؽ�Ʈ
    public GameObject talkScreen; // ��ȭâ
    private bool playerIn; // �÷��̾� ���� ����

    void Start()
    {
        npcText.enabled = false;
        talkScreen.SetActive(false);
    }

    void Update()
    {
        // �÷��̾ NPC ���� �ȿ� ���� ��
        if (playerIn)
        {
            if (talkScreen.activeSelf)
            {
                npcText.text = "��ȭ�� �����Ϸ��� 'ESC'�� �����ּ���";
            }
            else
            {
                npcText.text = "��ȭ�� �Ͻ÷��� '�����̽���'�� �����ּ���";
            }

            if (Input.GetKeyDown(KeyCode.Space) && !talkScreen.activeSelf)
            {
                talkScreen.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.Escape) && talkScreen.activeSelf)
            {
                talkScreen.SetActive(false);
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
            talkScreen.SetActive(false); // NPC�� ���� �� ��ȭâ ��Ȱ��ȭ
        }
    }
}
