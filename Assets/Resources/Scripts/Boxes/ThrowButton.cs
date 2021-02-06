using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowButton : MonoBehaviour
{
    private PaperBox boxScript;

    private void Start()
    {
        boxScript = transform.parent.gameObject.GetComponent<PaperBox>();
    }

    void OnMouseDown()
    {
        boxScript.ThrowOnClick();
    }

}
