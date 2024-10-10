using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npc01 : MonoBehaviour
{
    public Text npcText; // NPC 머리위의 텍스트
    public GameObject talkScreen; // 대화창
    private bool playerIn; // 플레이어 범위 판정
    public Text wrongOrderMessage; // 잘못된 대화 순서 메시지 텍스트

    // 대화 순서 제어를 위한 정적 변수들
    public static bool isReceptionistTalkCompleted = false; // 리셉션 NPC 대화 완료 여부
    public static bool isDoctorTalkCompleted = false; // 의사 NPC 대화 완료 여부
    public static bool isNurseTalkCompleted = false; // 간호사 NPC 대화 완료 여부

    public string npcRole; // NPC의 역할 ("reception", "doctor", "nurse")

    private bool showWrongOrderMessage; // 잘못된 메시지를 표시할지 여부

    void Start()
    {
        npcText.enabled = false;
        talkScreen.SetActive(false);
        wrongOrderMessage.enabled = false; // 메시지 처음에 비활성화
    }

    void Update()
    {
        if (playerIn)
        {
            // 대화 화면에 메시지 표시
            if (talkScreen.activeSelf)
            {
                npcText.text = "대화를 종료하려면 'ESC'를 눌러주세요";
            }
            else
            {
                npcText.text = "대화를 하시려면 '스페이스바'를 눌러주세요";
            }

            // 대화를 시작하려는 경우
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
                    showWrongOrderMessage = true; // 잘못된 대화 시도
                    wrongOrderMessage.text = "순서에 맞는 NPC와 먼저 대화하세요.";
                    wrongOrderMessage.enabled = true; // 메시지 활성화
                }
            }

            // 대화 종료
            if (Input.GetKeyDown(KeyCode.Escape) && talkScreen.activeSelf)
            {
                talkScreen.SetActive(false);

                // 대화 완료 상태 저장
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
            talkScreen.SetActive(false); // 범위를 벗어날 때 대화창 닫기
            wrongOrderMessage.enabled = false; // NPC를 떠날 때 잘못된 대화 메시지 비활성화
        }
    }
}
