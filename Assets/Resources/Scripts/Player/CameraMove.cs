using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject observable;
    public float speed;

    private Transform t;
    private float angle;
    private float distance;
    private bool moving = false;

    void Start()
    {
        t = observable.transform;
    }

    void Update()
    {
        // TRY AddForce IN PLAYER EXCEPT TRASNFROM.POSITION
        transform.position = t.position + new Vector3(0, 2.08f, -10);
        /*if (transform.position.x > t.position.x)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if (transform.position.x < t.position.x)

        if (transform.position.y != t.position.y+2.08f)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }*/
    }
}
