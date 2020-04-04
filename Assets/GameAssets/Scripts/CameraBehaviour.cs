using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Camera maincam;
 

    private void Start()
    {
        StartCoroutine(screenglitch());

    }


    IEnumerator screenglitch()
    {
        int cullingmask = maincam.cullingMask;
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSecondsRealtime(5);
            maincam.cullingMask = (1 << LayerMask.NameToLayer("false")|1<<LayerMask.NameToLayer("glitchingtrue"));
            yield return new WaitForSecondsRealtime(0.5f);
            maincam.cullingMask = cullingmask;
            i--;
        }
    }
}

