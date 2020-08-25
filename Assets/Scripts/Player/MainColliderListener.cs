using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainColliderListener : MonoBehaviour
{
    private PlayerControl control;

    private string lastTag = "";

    private void Start()
    {
        control = transform.parent.GetComponent<PlayerControl>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string t = collision.gameObject.tag;
        if (t == "Collider" || t == "Glass" || t == "Paper" || t == "Metal" || t == "Plastic"/* || t == "StairCollider"*/)
        {
            Debug.Log("-->> " + t);
            lastTag = t;
            control.onGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        string t = collision.gameObject.tag;

        if (t == "Collider" /*|| t == "StairCollider"*/)
        {
            /*if (lastTag == "Collider" && lastTag == t)
                return;*/

            Debug.Log("<<-- " + t);
            control.onGround = false;
        }
    }

}
