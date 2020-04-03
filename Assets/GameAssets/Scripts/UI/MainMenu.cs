using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class MainMenu : MonoBehaviour
{
    private GameManager gm;
    private Canvas canvas;

    // This is to insure that inputs are after the canvas have appeared not before
    private bool falseInput = true;

    void Start()
    {
        gm = GameManager.Instance;
        canvas = GetComponent<Canvas>();
    }

    void Update()
    {
        if (Input.GetButtonUp("Cancel") && falseInput && canvas.enabled)
        {
            falseInput = false;
        }

        if (Input.GetButtonDown("Cancel") && !falseInput)
        {
            gm.isControllable = true;
            canvas.enabled = false;
            falseInput = true;
        }
    }
}
