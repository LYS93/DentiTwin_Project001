using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npc01 : MonoBehaviour
{
    public Text npcText; //npc 머리위의 텍스트
    public GameObject talkScreen; //대화창
    bool playerIn; //플레이어 범위판정
    
    
    void Start()
    {
        npcText.enabled = false;
        talkScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //대화창이 활성화 상태일때
        if(talkScreen.activeSelf)
        {
            npcText.text = "대화를 종료하려면 'ESC'를 눌러주세요";
        }
        else if (!talkScreen.activeSelf) //대화창이 비활성화 상태일때
        {
            npcText.text = "대화를 하시려면 '스페이스바'를 눌러주세요";
        }
        
        //플레이어가 npc범위 안으로 들어갔을때
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
            npcText.text = "대화를 하시려면 '스페이스바'를 눌러주세요";
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
