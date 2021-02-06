using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject headerObj;
    public GameObject textObj;

    private Text header;
    private Text text;
    private Button button;

    private void Start()
    {
        header = headerObj.GetComponent<Text>();
        text = textObj.GetComponent<Text>();
        button = headerObj.transform.parent.GetComponent<Button>();

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(OnClick);
    }

    private void ShowWindow(bool b)
    {
        headerObj.transform.parent.gameObject.SetActive(b);
    }

    public void StartTutorial()
    {
        ShowWindow(true);
        header.text = "Управляй Грирменом";
        text.text = "Нажимайте на <color=#0000ffff>стрелки</color>, чтобы двигатсья. Чтобы подобрать мусор, просто подойдите к нему. Нажмите на это окно, чтобы закрыть обучение.";
    }

    public void OnClick()
    {
        ShowWindow(false);
    }

}
