using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sound01 : MonoBehaviour
{
    public AudioSource[] backgroundAudioSources; // ����� ����� �ҽ� �迭
    public AudioSource[] soundEffectAudioSources; // ȿ���� ����� �ҽ� �迭
    public Slider backgroundVolumeSlider; // ����� �����̴�
    public Slider soundEffectVolumeSlider; // ȿ���� �����̴�
    public Text backgroundVolumeText; // ����� ���� ���� �ؽ�Ʈ
    public Text soundEffectVolumeText; // ȿ���� ���� ���� �ؽ�Ʈ

    
    private void Start()
    {
        // PlayerPrefs���� ���� �ҷ�����
        float savedBackgroundVolume = PlayerPrefs.GetFloat("BackgroundVolume",1f); // �⺻�� 1
        float savedSoundEffectVolume = PlayerPrefs.GetFloat("SoundEffectVolume",1f); // �⺻�� 1

        // �����̴��� �ʱ� �� ����
        backgroundVolumeSlider.value = savedBackgroundVolume;
        soundEffectVolumeSlider.value = savedSoundEffectVolume;

        // �ʱ� �ؽ�Ʈ ������Ʈ
        backgroundVolumeText.text = $"{Mathf.RoundToInt(savedBackgroundVolume * 100)}%";
        soundEffectVolumeText.text = $"{Mathf.RoundToInt(savedSoundEffectVolume * 100)}%";

        // ����� �����̴� �� ���� ������
        backgroundVolumeSlider.onValueChanged.AddListener(delegate {
            for (int i = 0; i < backgroundAudioSources.Length; i++)
            {
                backgroundAudioSources[i].volume = backgroundVolumeSlider.value;
            }
            backgroundVolumeText.text = $"{Mathf.RoundToInt(backgroundVolumeSlider.value * 100)}%";

            // ������ PlayerPrefs�� ����
            PlayerPrefs.SetFloat("BackgroundVolume", backgroundVolumeSlider.value);
        });

        // ȿ���� �����̴� �� ���� ������
        soundEffectVolumeSlider.onValueChanged.AddListener(delegate {
            for (int i = 0; i < soundEffectAudioSources.Length; i++)
            {
                soundEffectAudioSources[i].volume = soundEffectVolumeSlider.value;
            }
            soundEffectVolumeText.text = $"{Mathf.RoundToInt(soundEffectVolumeSlider.value * 100)}%";

            // ������ PlayerPrefs�� ����
            PlayerPrefs.SetFloat("SoundEffectVolume", soundEffectVolumeSlider.value);
        });
    }
}
