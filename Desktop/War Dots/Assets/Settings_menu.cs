﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
public class Settings_menu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_Dropdown resolutionDropdown;
    //public Dropdown resolutionDropdown;
    Resolution[] resolutions;
    private void Start()
    {
        resolutions=Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if( resolutions[i].width == Screen.currentResolution.width&&
                 resolutions[i].height==Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    public void SetVolume (float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }
    public void SetFullScreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
