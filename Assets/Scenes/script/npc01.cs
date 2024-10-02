using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npc01 : MonoBehaviour
{
    public Text npcText; //npc �Ӹ����� �ؽ�Ʈ
    public GameObject talkScreen; //��ȭâ
    bool playerIn; //�÷��̾� ��������
    
    
    void Start()
    {
        npcText.enabled = false;
        talkScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //��ȭâ�� Ȱ��ȭ �����϶�
        if(talkScreen.activeSelf)
        {
            npcText.text = "��ȭ�� �����Ϸ��� 'ESC'�� �����ּ���";
        }
        else if (!talkScreen.activeSelf) //��ȭâ�� ��Ȱ��ȭ �����϶�
        {
            npcText.text = "��ȭ�� �Ͻ÷��� '�����̽���'�� �����ּ���";
        }
        
        //�÷��̾ npc���� ������ ������
        if (playerIn)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                talkScreen.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                talkScreen.SetActive(false);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            npcText.enabled = true;
            npcText.text = "��ȭ�� �Ͻ÷��� '�����̽���'�� �����ּ���";
            playerIn = true;        
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            npcText.enabled = false;
            playerIn = false;
        }
    }
}
