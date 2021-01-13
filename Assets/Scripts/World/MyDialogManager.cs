using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Doublsb.Dialog;

public class MyDialogManager : MonoBehaviour
{

    public DialogManager manager;
    public GameObject nameLabel;
    private Text nameText;

    void Start()
    {
        DialogData dialog = new DialogData("Добрый день", "Гринмен");

        nameText = nameLabel.GetComponent<Text>();

        nameText.text = dialog.Character;
        manager.Show(dialog);
    }
}
