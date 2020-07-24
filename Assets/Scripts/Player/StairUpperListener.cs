using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairUpperListener : MonoBehaviour
{
    private WalkStairs main;

    // Start is called before the first frame update
    void Start()
    {
        main = transform.parent.GetComponent<WalkStairs>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collider")
            main.upperApproval = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collider")
            main.upperApproval = true;
    }

}
