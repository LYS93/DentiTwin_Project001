using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npc01 : MonoBehaviour
{
    public Text npcText; // NPC 머리위의 텍스트
    public GameObject talkScreen; // 대화창
    private bool playerIn; // 플레이어 범위 판정

    void Start()
    {
        npcText.enabled = false;
        talkScreen.SetActive(false);
    }

    void Update()
    {
        // 플레이어가 NPC 범위 안에 있을 때
        if (playerIn)
        {
            if (talkScreen.activeSelf)
            {
                npcText.text = "대화를 종료하려면 'ESC'를 눌러주세요";
            }
            else
            {
                npcText.text = "대화를 하시려면 '스페이스바'를 눌러주세요";
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
            talkScreen.SetActive(false); // NPC를 떠날 때 대화창 비활성화
        }
    }
}
