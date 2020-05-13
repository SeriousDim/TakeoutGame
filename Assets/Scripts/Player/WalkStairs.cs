using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkStairs : MonoBehaviour
{

    void Start()
    {
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "StairCollider")
        {
            Debug.Log(this.transform.name);
            this.transform.parent.position += new Vector3(0, 0.485f, 0);
        }
    }

}
