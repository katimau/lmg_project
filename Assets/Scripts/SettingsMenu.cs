using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    private SettingsObject settings;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;
    public InputField nameInputField;

    void Start()
    {
        if (musicVolumeSlider == null || sfxVolumeSlider == null || nameInputField == null)
        {
            Debug.LogError("Ui controls not set!");
        }
    }

    void OnEnable()
    {
        Debug.Log("Loading settings...");
        settings = SettingsManager.LoadSettings();
        Debug.Log("Settings loaded.");
        SetControlValues();
    }

    public void ResetSettings()
    {
        settings = new SettingsObject();
        SetControlValues();
    }

    public void SaveSettings()
    {
        GetControlValues();
        if (settings != null)
        {
            Debug.Log("Saving settings...");
            SettingsManager.SaveSettings(settings);
            Debug.Log("Settings saved.");
        }
    }

    private void SetControlValues()
    {
        musicVolumeSlider.value = settings.musicVolume;
        sfxVolumeSlider.value = settings.sfxVolume;
        nameInputField.text = settings.playerName;
    }

    private void GetControlValues()
    {
        settings.musicVolume = musicVolumeSlider.value;
        settings.sfxVolume = sfxVolumeSlider.value;
        settings.playerName = nameInputField.text;
    }
}
