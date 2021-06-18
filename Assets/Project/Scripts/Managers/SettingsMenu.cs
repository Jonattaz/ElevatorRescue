using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    // Variable
    [SerializeField] private AudioMixer audioMixer;

    // Controls the volume mixer 
    public void SetVolume(float Volume)
    {
        audioMixer.SetFloat("Volume", Volume);
    }

    // Load another scenes
    public void SceneOptions(int SceneOptions)
    {
        SceneManager.LoadScene(SceneOptions);
    }
}
