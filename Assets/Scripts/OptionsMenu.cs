using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider effectsSlider;
    void Start()
    {
        musicSlider.onValueChanged.AddListener(AudioManager.instance.SetMusicVolume);
        effectsSlider.onValueChanged.AddListener(AudioManager.instance.SetSoundVolume);
    }
}
