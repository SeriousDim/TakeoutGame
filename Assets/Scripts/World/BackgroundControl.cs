using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControl : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float coordRight;

    void Start()
    {
        
    }

    void Update()
    {
        Move(Time.deltaTime, Input.GetAxis("Horizontal"));
    }

    void Move(float delta, float direction)
    {
        float px = player.transform.position.x;
        float bgx = transform.position.x;

        // bgx -= speed * delta * direction;

        if (px >= bgx + coordRight)
            bgx += coordRight;
        if (px <= bgx)
            bgx -= coordRight;

        transform.position = new Vector3(bgx, 0, 0);
    }

}
