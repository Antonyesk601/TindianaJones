using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        float moving = Input.GetAxis("Horizontal") * speed;
        if (moving > speed)
        {
            moving = speed;
            Debug.Log(moving + " " + speed);
        }
        gameObject.transform.Translate(moving, 0, 0);
        

    }
}
