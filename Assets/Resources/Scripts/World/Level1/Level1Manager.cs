using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Takeout.DataWrappers;

/*
 * Stars indexes: 0 - collection; 1 - advert; 2 - lvl complete
 */
public class Level1Manager : LevelManager
{
    public GameObject tutorial;

    private bool tutorialThreeLeftShowed = false;
    private Level1Tutorial manager;

    private void Start()
    {
        this.thisLevelName = Levels.LEVEL1;
        desc = new Descriptions[] { Descriptions.COLLECTION_RUBBISH, Descriptions.ADVERT_LVL1, Descriptions.LEVEL_COMPLETE };

        manager = tutorial.GetComponent<Level1Tutorial>();

        base.Start();
    }

    private void Update()
    {
        base.Update();

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

    public void SetTotalText()
    {
        if (stars[2])
            this.totalText.text += "- Уровень пройден\n";
        if (stars[0])
            this.totalText.text += "- Найден коллекционный мусор\n";
        if (stars[1])
            this.totalText.text += "- Реклама использована\n";
    }

    public override void FinishLevel()
    {
        GiveStar(2);

        SetTotalText();

        base.FinishLevel();
    }

    public void ApplyAdvertStar()
    {
        GiveStar(1);
        // change advert

        Debug.Log("Level1Manager.ApplyAdvertStar: star 1 added");
    }

}
