using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class nextLevel : MonoBehaviour
{
    GameManager gm;
    public isCharged opendoor;
    bool ischarged;
    private void Start()
    {
        gm = GameManager.Instance;
    }
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    { if (opendoor.ischarged) {
            ischarged = true;
            if (collision.tag == "Player")
                 {
                    gm.Win();
                }
            else
            {
                ischarged = false;
            }
        
        }
    }
}
