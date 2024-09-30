using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class start01 : MonoBehaviour
{
    public GameObject optionsPanel; // 옵션 패널
    public Button[] buttons; //옵션 패널 이외의 버튼
    float restart;//다시 시작할때
    public GameObject startScreen;//시작스크린
    
    void Start()
    {
        // 시작 시 옵션 패널을 비활성화
        optionsPanel.SetActive(false);
        
        //시작스크린이 없을때
        if(startScreen == null)
        {
            PlayerPrefs.DeleteKey("Restart");//Restart값 초기화
        }

    }
    void Update()
    {
        // 옵션 패널의 활성화 상태에 따라 버튼 상태 변경
        bool isActive = optionsPanel.activeSelf;

        // 버튼 배열을 순회하며 interactable 속성 설정
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = !isActive; // 옵션 패널이 활성화되면 버튼 비활성화
        }
    }
    public void OnOptions()
    {
        // 옵션 패널을 활성화
        optionsPanel.SetActive(true);
    }

    public void OffOptions()
    {
        // 옵션 패널을 비활성화
        optionsPanel.SetActive(false);
    }
    public void doc_scene()
    {
        // 의사 씬으로 전환
        SceneManager.LoadScene("DoctorScene");
    }
    public void pat_scene()
    {
        // 환자 씬으로 전환
        SceneManager.LoadScene("PatientScene");
    }
    public void back()
    {
        //시작 씬으로 전환
        SceneManager.LoadScene("StartScene");
        //재시작에는 시작스크린이 안뜨도록
        restart += 1f;
        PlayerPrefs.SetFloat("Restart", restart);
    }
    public void Quit()
    {
        //게임종료
        Application.Quit();
        
        PlayerPrefs.DeleteAll(); // 모든 PlayerPrefs 삭제
        PlayerPrefs.Save(); // 변경사항 저장

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // 에디터에서는 플레이 모드 종료
#endif
    }

}
