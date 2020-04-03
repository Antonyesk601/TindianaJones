using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Whips : MonoBehaviour
{
    private GameManager gm;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        gm = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = $"Whips: {gm.whips}";
    }
}
