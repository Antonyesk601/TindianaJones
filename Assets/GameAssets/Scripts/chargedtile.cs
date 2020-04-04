using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chargedtile : MonoBehaviour
{
    public isCharged activate;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (activate.ischarged)
        {
            if (gameObject.transform.GetChild(0).gameObject.name=="spikeholder")
            {
                gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
            else
            {
                gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(true);

            }
        }
        else
        {
            if (gameObject.transform.GetChild(0).gameObject.name == "spikeholder")
            {
                gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(false);

            }
        }
    }
}
