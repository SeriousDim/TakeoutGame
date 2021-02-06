using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

using Doublsb.Dialog;

/* Содержит осовные методы для работы с диалогами.
 * Наследуем этот класс и реализуем в нем логику диалога.
 * Каждую ветку диалога рекомендуется делать отдельным
 * методом. Имя каждого персонажа - строковой константой.
 */
public class AbstractDialog : MonoBehaviour
{
    public const string GREENMAN = "Гринмен";

    public DialogManager manager;
    public GameObject nameLabel;
    public int size = 30;

    private Text nameText;

    public void Start()
    {
        nameText = nameLabel.GetComponent<Text>();
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
    }

    public void ShowCharacterName(string s)
    {
        nameText.text = s;
    }

    public DialogData CreateGreenmanQuote(string q)
    {
        return new DialogData(Size() + q, "Greenman");
    }

    public DialogData CreateGreenmanQuote(string q, UnityAction call)
    {
        return new DialogData(Size() + q, "Greenman", call);
    }

    public string Size()
    {
        return "/size:" + size + "/";
    }

    public string Blue(string text)
    {
        return "/color:blue/" + text + "/color:white/";
    }

    public string Yellow(string text)
    {
        return "/color:yellow/" + text + "/color:white/";
    }

    public void SkipCurrentDialog()
    {
        Debug.Log("Dialog is skipped");
        manager.StopAllCoroutines();
        manager.Hide();
    }
}
