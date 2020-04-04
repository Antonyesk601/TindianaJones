using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chargedtile : MonoBehaviour
{
    public isCharged activate;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        if (activate.ischarged)
        {
            gameObject.SetActive(true);
            
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
