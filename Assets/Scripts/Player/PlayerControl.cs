using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    SpriteRenderer renderer;
    Animator animator;
    BoxCollider2D collider;
    Rigidbody2D body;

    private bool onGround = true;
    private bool onLadder = false;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        ClimbLadder();
    }

    void Update()
    {
        Move(Input.GetAxis("Horizontal"));
        Jump((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)));
    }

    void Jump(bool b)
    {
        if (b && onGround && !onLadder)
        {
            body.AddForce(Vector2.up * jumpForce);
            onGround = false;
        }
    }

    void Move(float direction)
    {
        Vector2 newPosition = Vector2.right * direction * speed * Time.deltaTime;

        if ((direction > 0 && renderer.flipX) || (direction < 0 && !renderer.flipX)) renderer.flipX = !renderer.flipX;

        body.position += newPosition;
        animator.SetBool("running", (direction != 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collider" && collision.gameObject.layer == 0)
        {
            onGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collider" && collision.gameObject.layer == 0)
        {
            // onGround = false;
        }
    }

    void ClimbLadder()
    {
        if (onLadder)
        {
            if (Input.GetKey(KeyCode.W))
            {
                gameObject.transform.position += new Vector3(0, speed * 0.02f, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                gameObject.transform.position += new Vector3(0, -speed * 0.02f, 0);
            }
        }
    }

    public void OnLadderEnter()
    {
        onLadder = true;
        body.gravityScale = 0;
        body.velocity = Vector3.zero;
        // body.bodyType = RigidbodyType2D.Dynamic;
    }

    public void onLadderExit()
    {
        onLadder = false;
        body.gravityScale = 1;
        // body.bodyType = RigidbodyType2D.Dynamic;
    }

}
