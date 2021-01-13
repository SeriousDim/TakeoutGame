using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Likecoin : MonoBehaviour
{
    public int price = 1;

    private LikecoinCollector collector;
    private Animator animator;
    private BoxCollider2D collider;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        collector = player.GetComponent<LikecoinCollector>();

        animator = gameObject.GetComponent<Animator>();
        collider = gameObject.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "MainCollider")
        {
            collector.AddScore(price);
            collider.enabled = false;
            
            animator.SetBool("collected", true);
            Destroy(transform.parent.gameObject, 0.3f);
        }
    }
}
