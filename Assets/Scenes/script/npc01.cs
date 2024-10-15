using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class npc01 : MonoBehaviour
{
    public Text npcText; // NPC 머리위의 텍스트
    public GameObject talkScreen; // 대화창
    public GameObject buttonPanel; // 버튼 패널 (미니게임 여부 확인)
    public Text wrongOrderMessage; // 잘못된 대화 순서 메시지 텍스트
    private bool playerIn; // 플레이어 범위 판정

    public static bool isReceptionistTalkCompleted = false;
    public static bool isDoctorTalkCompleted = false;
    public static bool isNurseTalkCompleted = false;

    public string npcRole; // NPC의 역할 ("reception", "doctor", "nurse")

    private bool showWrongOrderMessage; // 잘못된 메시지를 표시할지 여부

    void Start()
    {
        npcText.enabled = false;
        talkScreen.SetActive(false);
        buttonPanel.SetActive(false); // 처음에는 버튼 패널을 비활성화
        wrongOrderMessage.enabled = false; // 잘못된 대화 순서 메시지 비활성화

        // 씬 시작 시 대화 순서 상태 초기화
        isReceptionistTalkCompleted = false;
        isDoctorTalkCompleted = false;
        isNurseTalkCompleted = false;
    }

    void Update()
    {
        if (playerIn)
        {
            // 대화 화면에 메시지 표시
            if (talkScreen.activeSelf)
            {
                npcText.text = "'스페이스바'를 눌러 대화를 넘겨주세요\n대화를 그만 하시려면 'ESC'를 눌러주세요";
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
                    wrongOrderMessage.text = "원무과-의사-간호사 순서로 대화를 해주세요";
                    wrongOrderMessage.enabled = true; // 잘못된 대화 순서 메시지 활성화
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

                    // 간호사 대화가 끝나면 버튼 패널을 활성화
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
            wrongOrderMessage.enabled = false; // 범위를 벗어나면 잘못된 대화 순서 메시지 비활성화
            buttonPanel.SetActive(false); // NPC를 떠나면 버튼 패널도 비활성화
        }
    }

    // 1. 미니게임으로 넘어가는 버튼 메서드
    public void StartMiniGame()
    {
        SceneManager.LoadScene("MiniGameScene"); // "MiniGameScene"을 미니게임 씬의 이름으로 변경
    }

    // 2. 취소 버튼 메서드
    public void CancelMiniGame()
    {
        buttonPanel.SetActive(false); // 버튼 패널 비활성화
    }
}
