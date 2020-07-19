using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject aboutPanel;
    public GameObject levelSelector;
    public GameObject mainMenu;
    Animator aboutPanelAnimator;
    Animator levelSelectorAnimator;

    void Start()
    {
        aboutPanelAnimator = aboutPanel.GetComponent<Animator>();
        levelSelectorAnimator = levelSelector.GetComponent<Animator>();
    }

    public void ShowAboutPanel(bool b)
    {
        if (b)
        {
            aboutPanelAnimator.SetBool("clicked", true);
        } else
        {
            aboutPanelAnimator.SetBool("clicked", false);
        }
    }

    public void ShowLevelSelector(bool b)
    {
        if (b)
        {
            levelSelectorAnimator.SetBool("clicked", true);
        }
        else
        {
            levelSelectorAnimator.SetBool("clicked", false);
        }
    }

    public void CloseApp()
    {
        Application.Quit();
    }
}
