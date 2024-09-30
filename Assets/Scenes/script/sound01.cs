using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sound01 : MonoBehaviour
{
    public AudioSource[] audioSources; // 여러 개의 AudioSource를 위한 배열
    public Slider volumeSlider; // 연결할 Slider
    public Text volumeText; // 현재 음량을 표시할 Text (선택적)

    private void Start()
    {
        // 슬라이더의 초기 값 설정
        volumeSlider.value = audioSources[0].volume;

        // 슬라이더 값이 변경될 때마다 모든 AudioSource의 음량 조정
        volumeSlider.onValueChanged.AddListener(delegate {
            for (int i = 0; i < audioSources.Length; i++)
            {
                audioSources[i].volume = volumeSlider.value;
            }

            // 음량 텍스트 업데이트
            if (volumeText != null)
                volumeText.text = $"{Mathf.RoundToInt(volumeSlider.value * 100)}%";
        });
    }
}
