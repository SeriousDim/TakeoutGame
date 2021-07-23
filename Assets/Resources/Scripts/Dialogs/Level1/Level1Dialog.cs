using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;

using Doublsb.Dialog;

public class Level1Dialog : AbstractDialog
{
    public GameObject tutorialManager;

    private Level1Tutorial tutorial;

    void Start()
    {
        base.Start();

        tutorial = tutorialManager.GetComponent<Level1Tutorial>();

        ShowCharacterName(GREENMAN);
        manager.Show(Branch1());
    }

    // в самом начале уровня
    public List<DialogData> Branch1()
    {
        var dialogs = new List<DialogData>();

        dialogs.Add(CreateGreenmanQuote("Привет/wait:0.5/. Добро пожаловать в славный город Свердчелск."));

        dialogs.Add(CreateGreenmanQuote("Это очень красивый город, с красивой природой и многовековой историей."));

        dialogs.Add(CreateGreenmanQuote("Но я постоянно вижу, как люди просто портят красоту этого города и природу своим..."));

        dialogs.Add(CreateGreenmanQuote("... мусором."));

        dialogs.Add(CreateGreenmanQuote("Кто-то должен все это исправить, кто-то должен показать, что этого всего не должно быть."));

        dialogs.Add(CreateGreenmanQuote("Меня зовут "+ Yellow("Гринмен") +", /wait:0.5/и я поставил себе именно такую цель!"));

        dialogs.Add(CreateGreenmanQuote("Но мне понадобится "+ Blue("твоя") +" помощь."));

        var choice = StartChoice1();

        dialogs.Add(choice);

        return dialogs;
    }

    public DialogData StartChoice1()
    {
        var choice = CreateGreenmanQuote("Поможешь сделать этот мир снова чистым?");
        choice.SelectList.Add("Yes", "Да");
        choice.SelectList.Add("Def", "Определенно");
        choice.SelectList.Add("Abs", "Абсолютно");

        choice.Callback = () => CheckChoice1();

        return choice;
    }

    public void CheckChoice1()
    {
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("Отлично, /wait:0.5/спасибо. Тогда начнем."));
        dialogTexts.Add(new DialogData("Очистим этот двор!", "", () => { tutorial.StartTutorial(); }));

        manager.Show(dialogTexts);
    }

    // при подходе к бачку
    public void Branch2()
    {
        var dialogs = new List<DialogData>();

        dialogs.Add(CreateGreenmanQuote(
            "Это - один из /color:yellow/бачков для мусора/color:white/. Таких на каждом " +
            "уровне много."));
        dialogs.Add(CreateGreenmanQuote("Проблема в том, что их сначала нужно найти."));
        dialogs.Add(CreateGreenmanQuote("Каждый бачок предназначен для определенного " +
            Yellow("типа мусора")));
        dialogs.Add(CreateGreenmanQuote("В такие бачки нужно " +
            Yellow("выбросить ") + "весь мусор на уровне"));
        dialogs.Add(CreateGreenmanQuote("Надо найти мусор."));

        ShowCharacterName(GREENMAN);
        manager.Show(dialogs);
    }

    // при подборе первого мусора - книги
    public void Story1()
    {
        var dialogs = new List<DialogData>();

        dialogs.Add(CreateGreenmanQuote("Учебник. /wait:0.5/Видимо, кого-то так и не научили" +
            " выбрасывать мусор туда, куда надо", () => { tutorial.Tutorial2(); }));

        ShowCharacterName(GREENMAN);
        manager.Show(dialogs);
    }

    // выкинута книга
    public void Branch3()
    {
        var dialogs = new List<DialogData>();

        dialogs.Add(CreateGreenmanQuote("Здорово! /wait:0.5/Первый шаг уже сделан."));
        dialogs.Add(CreateGreenmanQuote("Нужно найти оставшийся мусор и правильно " +
            "его утилизировать."));

        ShowCharacterName(GREENMAN);
        manager.Show(dialogs);
    }

    // ваша реклама
    public void Branch4()
    {
        var dialogs = new List<DialogData>();

        dialogs.Add(CreateGreenmanQuote("О! /wait:0.5/Пожалуй здесь может быть МОЯ реклама.",
            () => tutorial.TutorialAdvert()));

        ShowCharacterName(GREENMAN);
        manager.Show(dialogs);
    }
}


