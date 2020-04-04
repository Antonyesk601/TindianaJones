using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class nextLevel : MonoBehaviour
{
    GameManager gm;
    private void Start()
    {
        gm = GameManager.Instance;
    }
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetKeyUp(KeyCode.C))
            {
                if (gameObject.GetComponent<isCharged>().ischarged)
                {
                    gm.Win();
                }
            }
        }
    }
}
