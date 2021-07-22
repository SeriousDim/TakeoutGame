using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spriter2UnityDX;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    public float runSpeed;
    public float jumpForce;
    public float ladderSpeed;

    public float fovMax;

    SpriteRenderer renderer;
    EntityRenderer entityRenderer;
    Animator animator;
    BoxCollider2D collider;
    Rigidbody2D body;

    public bool onGround = true;
    private bool onLadder = false;
    private float gravityScale;

    private float mobileLadderClimbingDir = 0.0f;
    private float mobileHorizontalMove = 0.0f;
    private bool mobileJump = false;

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

    public void DoMobileControl()
    {
        Move(mobileHorizontalMove);
        Jump(mobileJump);
        ClimbMobile(mobileLadderClimbingDir);
    }

    public void OnMobileClimb(float f)
    {
        mobileLadderClimbingDir = f;
    }

    public void OnMobileJump(bool b)
    {
        mobileJump = b;
    }

    public void OnMobileHorizontalTouched(float f)
    {
        mobileHorizontalMove = f;
    }

    void Update()
    {
#if UNITY_ANDROID
        DoMobileControl();
#endif

#if UNITY_STANDALONE
        Move(Input.GetAxis("Horizontal"));
        Jump((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)));
        ClimbLadder();
#endif
    }

    public void Jump(bool b)
    {
        if (b && onGround && !onLadder)
        {
            body.AddForce(Vector2.up * jumpForce);
            //onGround = false;
        }
    }

    public void Move(float direction)
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

    public void ClimbMobile(float direction)
    {
        if (onLadder)
        {
            gameObject.transform.position += new Vector3(0, direction * ladderSpeed, 0) * Time.deltaTime;
        }
    }

    public void ClimbLadder()
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
