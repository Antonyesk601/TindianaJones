using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Camera maincam;
    public Camera glitchcam;
    bool x;
    private void Start()
    {
        StartCoroutine(screenglitch());
        x = true;
    }


    IEnumerator screenglitch()
    {
        while (x) {
            glitchcam.gameObject.transform.position = maincam.gameObject.transform.position;
            glitchcam.gameObject.transform.rotation = maincam.gameObject.transform.rotation;
            yield return new WaitForSecondsRealtime(10);
            maincam.gameObject.SetActive(false);
            glitchcam.gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(2);
            maincam.gameObject.SetActive(true);
            glitchcam.gameObject.SetActive(false);

        } 
    }

    }


