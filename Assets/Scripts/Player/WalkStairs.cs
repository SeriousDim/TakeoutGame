using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkStairs : MonoBehaviour
{
    Transform parent;

    void Start()
    {
        parent = transform.parent;
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 1)
        {
            parent.position += new Vector3(0, 0.485f, 0);
            Debug.Log("I touched StairMap");
        }
    }

}
