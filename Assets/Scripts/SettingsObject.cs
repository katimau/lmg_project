using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SettingsObject
{
    public float musicVolume;
    public float sfxVolume;
    public string playerName;

    public SettingsObject()
    {
        this.musicVolume = 0.5f;
        this.sfxVolume = 0.5f;
        this.playerName = "Player";
    }

    public SettingsObject(float musicVolume, float sfxVolume, string playerName)
    {
        this.musicVolume = musicVolume;
        this.sfxVolume = sfxVolume;
        this.playerName = playerName;
    }
}
