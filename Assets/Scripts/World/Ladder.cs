using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public GameObject player;

    private PlayerControl control;

    // Start is called before the first frame update
    void Start()
    {
        control = player.GetComponent<PlayerControl>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            control.OnLadderEnter();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            control.onLadderExit();
        }
    }

}
