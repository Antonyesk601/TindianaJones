using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Camera maincam;
    public Camera glitchcam;

    private void Start()
    {
        StartCoroutine(screenglitch());

    }


    IEnumerator screenglitch()
    {
        for (int i = 0; i < 10; i++)
        {
            glitchcam.gameObject.transform.position = maincam.gameObject.transform.position;
            glitchcam.gameObject.transform.rotation = maincam.gameObject.transform.rotation;
            yield return new WaitForSecondsRealtime(5);
            maincam.gameObject.SetActive(false);
            glitchcam.gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(0.5f);
            maincam.gameObject.SetActive(true);
            glitchcam.gameObject.SetActive(false);
            i--;
        }
    }
}

