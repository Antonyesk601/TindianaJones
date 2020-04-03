using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Camera maincam;
    public GameObject player;
    void Update()
    {
        StartCoroutine(screenglitch());
        Debug.Log("coroutine finished");
    }
    IEnumerator screenglitch()
    {
        yield return new WaitForSeconds(15);
        maincam.cullingMask = (1 << LayerMask.NameToLayer("Ground"));
        Debug.Log(true);
        yield return new WaitForSeconds(3);
        maincam.cullingMask = (1 << LayerMask.NameToLayer("UI")& LayerMask.NameToLayer("Ground") << LayerMask.NameToLayer("false"));
    }
}
