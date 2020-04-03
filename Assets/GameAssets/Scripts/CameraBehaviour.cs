using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Camera maincam;
    public Camera glitchcam;

    void Update()
    {
        glitchcam.gameObject.transform.position = maincam.gameObject.transform.position;
        glitchcam.gameObject.transform.rotation = maincam.gameObject.transform.rotation;
        StartCoroutine(screenglitch());
    }
    IEnumerator screenglitch()
    {

        yield return new WaitForSeconds(10);
        maincam.gameObject.SetActive(false);
        glitchcam.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        maincam.gameObject.SetActive(true);
        glitchcam.gameObject.SetActive(false);
    }
}
}
