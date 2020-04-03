using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class movement : MonoBehaviour
{

    private Rigidbody2D rigidBody;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool isLeft = false;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movingSpeed = Input.GetAxis("Horizontal") ;

        rigidBody.velocity = Vector2.right * movingSpeed + Vector2.up * rigidBody.velocity.y;

        animator.SetFloat("speed", Mathf.Abs(rigidBody.velocity.x));
        if (rigidBody.velocity.x < 0)
            isLeft = true;
        else if (rigidBody.velocity.x > 0)
            isLeft = false;

        spriteRenderer.flipX = isLeft;


    }
}
