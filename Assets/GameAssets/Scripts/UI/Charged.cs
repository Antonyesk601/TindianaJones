using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Charged : MonoBehaviour
{
    private GameManager gm;
    private Text text;
    private float t = 0;
    private float direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        gm = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        var colorOff = new Color(text.color.r, text.color.g, text.color.b, 0.04f);
        var colorOn = new Color(text.color.r, text.color.g, text.color.b, 1f);
        t += direction * Time.deltaTime / 2;
        if (t >= 1)
        {
            direction = -1f;
        }
        else if (t <= 0)
        {
            direction = 1f;
        }


        if (!gm.isPlayerCharged)
        {
            text.color = colorOff;
        }
        else
        {
            text.color = Color.Lerp(colorOff, colorOn, t);
            //Debug.Log(text.color);
        }
    }
}
