using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : LevelManager
{
    public GameObject rubbish;
    public GameObject tutorial;

    private bool tutorialThreeLeftShowed = false;
    private Level1Tutorial manager;

    private void Start()
    {
        base.Start();

        manager = tutorial.GetComponent<Level1Tutorial>();
    }

    private void Update()
    {
        if (!tutorialThreeLeftShowed)
        {
            if (rubbish.transform.childCount <= 3)
            {
                manager.TutorialThreeLeft();
                tutorialThreeLeftShowed = true;
            }
        }
    }

    public override void ConfirmCollectionRubbish()
    {
        base.ConfirmCollectionRubbish();

        GiveStar(0);
        Debug.Log("Level1Manager.ConfirmCollectionRubbish: stars = " + stars.ToString());
    }

    public void ApplyAdvert()
    {

    }

}
