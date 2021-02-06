using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

using Doublsb.Dialog;


public class MyDialogManager : MonoBehaviour
{
    const string GREENMAN = "Гринмен";

    public DialogManager manager;
    public GameObject nameLabel;
    public TutorialManager tutorial;

    private Text nameText;

    void Start()
    {
        nameText = nameLabel.GetComponent<Text>();

        var dialogs = new List<DialogData>();
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

        dialogs.Add(CreateGreenmanQuote("Привет/wait:0.5/. Добро пожаловать в славный город Челск."));

        dialogs.Add(CreateGreenmanQuote("<здесь пару славных слов про город>"));

        dialogs.Add(CreateGreenmanQuote("Я постоянно вижу, как люди просто портят красоту этого городу и природу своим..."));

        dialogs.Add(CreateGreenmanQuote("... мусором."));

        dialogs.Add(CreateGreenmanQuote("Кто-то должен все это исправить/wait:0.5/, кто-то должен показать, что этого всего не должно быть."));

        dialogs.Add(CreateGreenmanQuote("Меня зовут /color:yellow//size:30/Гринмен/color:white/, /wait:0.5/и я поставил себе именно такую цель!"));

        dialogs.Add(CreateGreenmanQuote("Но мне понадобится /color:blue//size:30/твоя/color:white/ помощь."));

        var choice = StartChoice1();

        dialogs.Add(choice);

        ShowCharacterName(GREENMAN);
        manager.Show(dialogs);
    }

    private void ShowCharacterName(string s)
    {
        nameText.text = s;
    }

    private DialogData CreateGreenmanQuote(string q)
    {
        return new DialogData(q, "Greenman", () => ShowCharacterName(GREENMAN));
    }

    private DialogData StartChoice1()
    {
        var choice = CreateGreenmanQuote("Поможешь сделать этот мир снова чистым?");
        choice.SelectList.Add("Yes", "Да");
        choice.SelectList.Add("Def", "Определенно");
        choice.SelectList.Add("Abs", "Абсолютно");

        choice.Callback = () => CheckChoice1();

        return choice;
    }

    private void CheckChoice1()
    {
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("Отлично, /wait:0.5/спасибо. Тогда начнем."));
        dialogTexts.Add(new DialogData("Очистим этот двор!", "", () => { tutorial.StartTutorial(); }));

        manager.Show(dialogTexts);
    }

    public void SkipCurrentDialog()
    {
        Debug.Log("Dialog is skipped");
        manager.StopAllCoroutines();
        manager.Hide();
    }
}
