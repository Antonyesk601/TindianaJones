using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider2D))]
public class isCharged : MonoBehaviour
{
    public bool ischarged = true;
    private GameManager gm;
    private void Start()
    {
        gm = GameManager.Instance;
        gameObject.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }
    private void Update()
    {
        gameObject.GetComponent<Animator>().SetBool("ischarged", ischarged);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetKeyUp(KeyCode.X))
            {
                if (ischarged)
                {
                    ischarged = false;
                    gm.isPlayerCharged = true;
                }
                else
                {
                    if (gm.isPlayerCharged)
                    {
                        ischarged = true;
                        gm.isPlayerCharged = false;

                    }
                }
            }
        }
    }
}
