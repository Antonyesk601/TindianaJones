using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    [RequireComponent(typeof(Animator))]

public class isCharged : MonoBehaviour
{
    public bool ischarged =true;
    private GameManager gm;
    private void Start()
    {
        gm = GameManager.Instance;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {if (collision.tag == "Player")
        {
            if (ischarged)
            {
                ischarged = false;
                gameObject.GetComponent<Animator>().SetBool("ischarged",ischarged);
                gm.isPlayerCharged = true;
            }
            else
            {
                if (gm.isPlayerCharged)
                {
                    ischarged = true;
                    gm.isPlayerCharged = false;
                    gameObject.GetComponent<Animator>().SetBool("ischarged", ischarged);

                }
            }
        }
    }
}
