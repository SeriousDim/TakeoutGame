using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeftRubbishNotifier : MonoBehaviour
{
    public GameObject leftNotifier;
    public GameObject rubbishObjectContainer;
    public int amountToAnnounce = 3;

    TextMeshProUGUI text;

    void Start()
    {
        text = leftNotifier.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void Show()
    {
        Debug.Log("LeftRubbishNotifier.Show : rubbish left = "+rubbishObjectContainer.transform.childCount);

        if (rubbishObjectContainer.transform.childCount - 1 <= amountToAnnounce)
        {
            leftNotifier.SetActive(true);
            text.text = "" + (rubbishObjectContainer.transform.childCount - 1);
        }
    }
}
