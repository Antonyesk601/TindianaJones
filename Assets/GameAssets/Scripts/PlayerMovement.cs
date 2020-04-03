using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float jump = 2.0f;
    [SerializeField]
    LayerMask platformMask;

    private Rigidbody2D rigidBody;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool isLeft = false;
    private Collider2D playerCollider;
    private GameManager gm;
    public bool isWhipping;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerCollider = GetComponent<Collider2D>();
        gm = GameManager.Instance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gm.isControllable)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                Debug.Log("Paused");
                gm.isControllable = false;
                GameObject.FindWithTag("UIMenu").GetComponent<Canvas>().enabled = true;
            }

            float movingSpeed = Input.GetAxis("Horizontal") * speed;

            rigidBody.velocity = Vector2.right * movingSpeed + Vector2.up * rigidBody.velocity.y;

            animator.SetFloat("speed", Mathf.Abs(rigidBody.velocity.x));
            if (rigidBody.velocity.x < 0)
                isLeft = true;
            else if (rigidBody.velocity.x > 0)
                isLeft = false;

            spriteRenderer.flipX = isLeft;

            if (isGrounded())
            {
                rigidBody.velocity += Vector2.up * Input.GetAxis("Jump") * jump;
            }
        }
    }

    private bool isGrounded()
    {
        float extraHeight = 0.01f;
        RaycastHit2D raycastHit = Physics2D.Raycast(playerCollider.bounds.center, Vector2.down, playerCollider.bounds.extents.y + extraHeight, platformMask);

        Color rayColor;
        if(raycastHit.collider != null)
        {
            rayColor = Color.red;
        }
        else
        {
            rayColor = Color.green;
        }
        //Debug.Log(raycastHit.collider);
     
        Debug.DrawRay(playerCollider.bounds.center, Vector2.down * (playerCollider.bounds.extents.y + extraHeight), rayColor);
        return raycastHit.collider != null;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKey(KeyCode.X))
        {
            isWhipping = false;
            animator.SetBool("isWhipping", isWhipping);
            Debug.Log("here");
            if (other.tag=="whip")
            {
                isWhipping = true;
                animator.SetBool("isWhipping", isWhipping);
                animator.Play("whip");
            }
            else
            {
                isWhipping = false;
            }
        }
    }
}
