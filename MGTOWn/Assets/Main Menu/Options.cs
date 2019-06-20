using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Dropdown resolutionDropdown;
    Resolution[] resolutions;

    void Awake()
    {
        resolutionDropdown.ClearOptions();

        resolutions = Screen.resolutions;
        List<string> options = new List<string>();
        int currentResIndex = 0;

        int lw = -1;
        int lh = -1;

        for (int i = 0; i < resolutions.Length; i++)
        {
            if (lw != resolutions[i].width && lh != resolutions[i].height)
            {
                var option = resolutions[i].width + " x " + resolutions[i].height;
                options.Add(option);

                lw = resolutions[i].width;
                lh = resolutions[i].height;
            }

            if (resolutions[i].width == Screen.width &&
                resolutions[i].height == Screen.height)
            {
                currentResIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen (bool isFulscreen)
    {
        Screen.fullScreen = isFulscreen;
    }

    public void SetResolution(int resIndex)
    {
        Resolution resolution = resolutions[resIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
