using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int score = 1000;

    private GameManager gm;

    void Start()
    {
        gm = GameManager.Instance;
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            gm.score += score;
            Destroy(gameObject);
        }
    }
}
