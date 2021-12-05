using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroUI : MonoBehaviour
{
    [SerializeField] private GameObject m_OptionsCanvas;
    [SerializeField] private GameObject m_ControlsCanvas;
    [SerializeField] private GameObject m_IntroCanvas;

    private void Start()
    {
        m_IntroCanvas.SetActive(true);
        m_ControlsCanvas.SetActive(false);
        m_OptionsCanvas.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GetStart()
    {
        m_IntroCanvas.SetActive(true);
        m_ControlsCanvas.SetActive(false);
        m_OptionsCanvas.SetActive(false);
    }

    public void GetOptions()
    {
        m_IntroCanvas.SetActive(false);
        m_ControlsCanvas.SetActive(false);
        m_OptionsCanvas.SetActive(true);
    }

    public void GetControls()
    {
        m_IntroCanvas.SetActive(false);
        m_ControlsCanvas.SetActive(true);
        m_OptionsCanvas.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("bye");
    }
}
