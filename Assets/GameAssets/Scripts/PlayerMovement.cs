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
    public float airbornespeed= 3f;
    [SerializeField]
    LayerMask platformMask;
    [SerializeField]
    LayerMask invisibleplatform;
    [SerializeField]
    LayerMask glitchingtrue;
    private Rigidbody2D rigidBody;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool isLeft = false;
    private Collider2D playerCollider;
    private GameManager gm;
    Vector3 newposition;

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
            if (isGrounded())
            {
                float movingSpeed = Input.GetAxis("Horizontal") * speed;
                rigidBody.velocity = Vector2.right * movingSpeed + Vector2.up * rigidBody.velocity.y;
            }
            else
            {
                float movingSpeed = Input.GetAxis("Horizontal") * airbornespeed;
                rigidBody.velocity = Vector2.right * movingSpeed + Vector2.up * rigidBody.velocity.y;
            }


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
        
            int i = 0;
            if (isLeft)
            {
                i = -1;
            }
            else
            {
                i = 1;
            }
            newposition = animator.gameObject.transform.position + i * new Vector3(2, 0, 0);
        
    }

    private bool isGrounded()
    {
        float extraHeight = 0.01f;
        RaycastHit2D raycastHit = Physics2D.Raycast(playerCollider.bounds.center, Vector2.down, playerCollider.bounds.extents.y + extraHeight, platformMask);
        RaycastHit2D raycastHitinvisible = Physics2D.Raycast(playerCollider.bounds.center, Vector2.down, playerCollider.bounds.extents.y + extraHeight, invisibleplatform);
        RaycastHit2D raycastHittrue = Physics2D.Raycast(playerCollider.bounds.center, Vector2.down, playerCollider.bounds.extents.y + extraHeight, glitchingtrue);

        Color rayColor;
        if (raycastHit.collider != null || raycastHitinvisible.collider != null || raycastHittrue.collider != null)
        {
            rayColor = Color.red;
        }
        else
        {
            rayColor = Color.green;
        }
        bool jump;
        //Debug.Log(raycastHit.collider);
        if (raycastHit.collider != null || raycastHitinvisible.collider != null||raycastHittrue.collider!=null)
        {
            jump = true;
        }
        else
        {
            jump= false;
        }
        Debug.DrawRay(playerCollider.bounds.center, Vector2.down * (playerCollider.bounds.extents.y + extraHeight), rayColor);
        return jump;

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isGrounded())
        {
            if (gm.whips > 0)
            {
                if (collision.tag == "whip")
                {
                    if (gameObject.GetComponent<Rigidbody2D>().velocity.magnitude == 0)
                    {
                        if (Input.GetKeyUp(KeyCode.X))
                        {
                            StartCoroutine(startanimation());
                        }
                    }
                }
            }
        }
    }
    
    IEnumerator startanimation()
    {
        spriteRenderer.flipX = !isLeft;
        animator.gameObject.transform.position = newposition + new Vector3(0, -0.5f, 0); ;
        gm.isControllable = false;
        animator.Play("whip");
        animator.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        gm.whips--;
        yield return new WaitForSeconds(1);
        gm.isControllable = true;
        animator.gameObject.transform.position = newposition + new Vector3(0, 0.5f, 0); ;
        animator.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        spriteRenderer.flipX = !isLeft;

    }
}
