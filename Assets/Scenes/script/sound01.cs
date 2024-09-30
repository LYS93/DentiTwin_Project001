using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sound01 : MonoBehaviour
{
    public AudioSource[] backgroundAudioSources; // 배경음 오디오 소스 배열
    public AudioSource[] soundEffectAudioSources; // 효과음 오디오 소스 배열
    public Slider backgroundVolumeSlider; // 배경음 슬라이더
    public Slider soundEffectVolumeSlider; // 효과음 슬라이더
    public Text backgroundVolumeText; // 배경음 현재 음량 텍스트
    public Text soundEffectVolumeText; // 효과음 현재 음량 텍스트

    private void Start()
    {
        // 배경음 슬라이더 초기 값 설정
        backgroundVolumeSlider.value = backgroundAudioSources[0].volume;
        soundEffectVolumeSlider.value = soundEffectAudioSources[0].volume;

        // 배경음 슬라이더 값 변경 리스너
        backgroundVolumeSlider.onValueChanged.AddListener(delegate {
            for (int i = 0; i < backgroundAudioSources.Length; i++)
            {
                backgroundAudioSources[i].volume = backgroundVolumeSlider.value;
            }
            backgroundVolumeText.text = $"{Mathf.RoundToInt(backgroundVolumeSlider.value * 100)}%";
        });

        // 효과음 슬라이더 값 변경 리스너
        soundEffectVolumeSlider.onValueChanged.AddListener(delegate {
            for (int i = 0; i < soundEffectAudioSources.Length; i++)
            {
                soundEffectAudioSources[i].volume = soundEffectVolumeSlider.value;
            }
            soundEffectVolumeText.text = $"{Mathf.RoundToInt(soundEffectVolumeSlider.value * 100)}%";
        });
    }
}
