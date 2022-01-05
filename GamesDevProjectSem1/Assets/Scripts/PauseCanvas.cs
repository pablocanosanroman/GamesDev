using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class PauseCanvas : MonoBehaviour
{
    [SerializeField] private GameObject m_InGameCanvas;
    [SerializeField] private GameObject m_PauseCanvas;
    [SerializeField] private AudioMixer m_AudioMixer;
    [SerializeField] private Slider m_MusicSlider;
    [SerializeField] private Slider m_SFXSlider;
    private float m_MusicVolume;
    private float m_SFXVolume;

    private void Start()
    {
        m_MusicVolume = PlayerPrefs.GetFloat("MusicVolumeValue");
        m_SFXVolume = PlayerPrefs.GetFloat("SFXVolumeValue");
        m_MusicSlider.value = m_MusicVolume;
        m_SFXSlider.value = m_SFXVolume;
    }

    public void SetMusicVolume(float sliderValue)
    {
        m_AudioMixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolumeValue", sliderValue);
    }

    public void SetSFXVolume(float sliderValue)
    {
        m_AudioMixer.SetFloat("SFXVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("SFXVolumeValue", sliderValue);
    }

    public void ResumeGame()
    {
        m_PauseCanvas.SetActive(false);
        m_InGameCanvas.SetActive(true);
        Time.timeScale = 1;
    }

    public void GetToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
