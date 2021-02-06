using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * THIS SCRIPT IS DEPRECATED.
 * Use Scripts/Player/LadderListener.cs instead.
 */

public class Ladder : MonoBehaviour
{
    private PlayerControl control;
    private GameObject mainCollider;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        control = player.GetComponent<PlayerControl>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Ladder: tag = "+collision.gameObject.tag);
        if (collision.gameObject.name == "MainCollider")
        {
            control.OnLadderEnter();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "MainCollider")
        {
            control.onLadderExit();
        }
    }

}
