using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Camera maincam;

    private Samples.SampleController sc;
 

    private void Start()
    {
        sc = maincam.GetComponent<Samples.SampleController>();
        StartCoroutine(screenglitch());
    }


    IEnumerator screenglitch()
    {
        int cullingmask = maincam.cullingMask;
        while (true)
        {
            yield return new WaitForSecondsRealtime(5);
            maincam.cullingMask = (1 << LayerMask.NameToLayer("false")|1<<LayerMask.NameToLayer("glitchingtrue"));
            sc.ColorDrift = 0.1f;
            sc.Intensity = 0.1f;
            sc.ScanLineJitter = 0.1f;
            yield return new WaitForSecondsRealtime(0.5f);
            maincam.cullingMask = cullingmask;
            sc.ColorDrift = 0f;
            sc.Intensity = 0f;
            sc.ScanLineJitter = 0f;
        }
    }
}

