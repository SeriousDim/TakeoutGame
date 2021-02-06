using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowButtonTutorial : MonoBehaviour
{
    public GameObject tutorialManager;

    private PaperBox boxScript;
    private Level1Tutorial tutorial;

    private bool tutorialShowed = false;

    private void Start()
    {
        boxScript = transform.parent.gameObject.GetComponent<PaperBox>();

        tutorial = tutorialManager.GetComponent<Level1Tutorial>();
    }

    void OnMouseDown()
    {
        boxScript.ThrowOnClick();

        if (!tutorialShowed)
        {
            tutorial.Tutorial3_1();
            tutorialShowed = true;
        }
    }
}
