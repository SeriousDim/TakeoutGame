using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkStairs : MonoBehaviour
{
    public bool upperApproval = true;
    public bool lowerApproval = false;

    void Start()
    {
    }

    void Update()
    {
        if (upperApproval && lowerApproval)
        {
            transform.parent.position += new Vector3(0, 0.485f, 0);
            upperApproval = true;
            lowerApproval = false;
        }
    }

}
