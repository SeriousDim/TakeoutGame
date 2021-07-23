using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject aboutPanel;
    public GameObject levelSelector;
    public GameObject mainMenu;
    public GameObject loading;
    Animator aboutPanelAnimator;
    Animator levelSelectorAnimator;

    private DataHolder dataHolder;

    void Start()
    {
        aboutPanelAnimator = aboutPanel.GetComponent<Animator>();
        levelSelectorAnimator = levelSelector.GetComponent<Animator>();
    }

    public void OpenDevPage()
    {
        Application.OpenURL("https://vk.com/dimaslykov");
    }

    public void OpenAppPage()
    {
        Application.OpenURL("http://unity3d.com/");
    }

    public void ShowAboutPanel(bool b)
    {
        mainMenu.SetActive(!b);
        aboutPanelAnimator.SetBool("clicked", b);
    }

    public void ShowLevelSelector(bool b)
    {
        mainMenu.SetActive(!b);
        levelSelectorAnimator.SetBool("clicked", b);
    }

    public void CloseApp()
    {
        Application.Quit();
    }

    public void OpenLevel(string s)
    {
        loading.SetActive(true);
        SceneManager.LoadScene(s);
    }
}
