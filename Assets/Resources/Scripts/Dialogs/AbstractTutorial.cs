using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class AbstractTutorial : MonoBehaviour
{
    public GameObject headerObj;
    public GameObject textObj;
    public GameObject clicker;

    private Button clickerBut;

    [HideInInspector]
    public Text header;
    [HideInInspector]
    public Text text;
    [HideInInspector]
    public Button button;

    public void Start()
    {
        header = headerObj.GetComponent<Text>();
        text = textObj.GetComponent<Text>();
        button = headerObj.transform.parent.GetComponent<Button>();

        clickerBut = clicker.GetComponent<Button>();

        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
    }

    public void SetButtonListener(UnityEngine.Events.UnityAction callback)
    {
        clickerBut.onClick.RemoveAllListeners();
        clickerBut.onClick.AddListener(callback);
    }

    public void ShowWindow(bool b)
    {
        headerObj.transform.parent.gameObject.SetActive(b);
        clicker.SetActive(b);
    }

    public string Blue(string text)
    {
        return "<color=#0000ffff>" + text + "</color>";
    }

    public void CloseOnClick()
    {
        ShowWindow(false);
    }
}
