using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spriter2UnityDX;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float ladderSpeed;

    SpriteRenderer renderer;
    EntityRenderer entityRenderer;
    Animator animator;
    BoxCollider2D collider;
    Rigidbody2D body;

    private bool onGround = true;
    private bool onLadder = false;
    private float gravityScale;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        entityRenderer = GetComponent<EntityRenderer>();
        animator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();

        gravityScale = body.gravityScale;
    }

    private void FixedUpdate()
    {
        
    }

    void Update()
    {
        Move(Input.GetAxis("Horizontal"));
        Jump((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)));
        ClimbLadder();
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
        animator.SetBool("running", (direction != 0));

        if (renderer != null)
        {
            if ((direction > 0 && renderer.flipX) || (direction < 0 && !renderer.flipX))
                renderer.flipX = !renderer.flipX;
        } else
        {
            if ((direction > 0 && transform.localScale.x > 0) || (direction < 0 && transform.localScale.x < 0))
            {
                Vector3 newScale = transform.localScale;
                newScale.x = -newScale.x;
                transform.localScale = newScale;
            }
        }

        body.position += newPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "Collider" || tag == "Glass" || tag == "Paper" || tag == "Metal" || tag == "StairCollider") /*&& collision.gameObject.layer == 0*/
        {
            onGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "Collider" || tag == "StairCollider")
        {
            onGround = false;
        }
    }

    void ClimbLadder()
    {
        if (onLadder)
        {
            if (Input.GetKey(KeyCode.W))
            {
                gameObject.transform.position += new Vector3(0, ladderSpeed, 0) * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                gameObject.transform.position += new Vector3(0, -ladderSpeed, 0) * Time.deltaTime;
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
        body.gravityScale = gravityScale;
        // body.bodyType = RigidbodyType2D.Dynamic;
    }

}
