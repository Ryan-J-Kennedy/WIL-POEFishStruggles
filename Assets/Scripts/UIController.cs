using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject howToPanel;

    public void StartButton()
    {
        SceneManager.LoadScene("River");
    }

    public void HowToButton()
    {
        menuPanel.SetActive(!menuPanel.activeSelf);
        howToPanel.SetActive(!howToPanel.activeSelf);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
