using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderListener : MonoBehaviour
{
    private PlayerControl control;

    // Start is called before the first frame update
    void Start()
    {
        control = transform.parent.GetComponent<PlayerControl>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("LadderListener: tag = " + collision.gameObject.tag);
        if (collision.gameObject.tag == "LadderMap")
        {
            control.OnLadderEnter();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LadderMap")
        {
            control.onLadderExit();
        }
    }

}
