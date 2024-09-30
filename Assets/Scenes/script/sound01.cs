using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sound01 : MonoBehaviour
{
    public AudioSource[] audioSources; // ���� ���� AudioSource�� ���� �迭
    public Slider volumeSlider; // ������ Slider
    public Text volumeText; // ���� ������ ǥ���� Text (������)

    private void Start()
    {
        // �����̴��� �ʱ� �� ����
        volumeSlider.value = audioSources[0].volume;

        // �����̴� ���� ����� ������ ��� AudioSource�� ���� ����
        volumeSlider.onValueChanged.AddListener(delegate {
            for (int i = 0; i < audioSources.Length; i++)
            {
                audioSources[i].volume = volumeSlider.value;
            }

            // ���� �ؽ�Ʈ ������Ʈ
            if (volumeText != null)
                volumeText.text = $"{Mathf.RoundToInt(volumeSlider.value * 100)}%";
        });
    }
}
