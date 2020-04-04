using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class nextLevel : MonoBehaviour
{
    GameManager gm;
    public isCharged opendoor;
    bool ischarged;
    private void Start()
    {
        gm = GameManager.Instance;
    }
    private void Update()
    {

        gameObject.GetComponent<Animator>().SetBool("ischarged", ischarged);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (opendoor.ischarged)
        {
            ischarged = true;
            if (collision.tag == "Player")
            {
                gm.Win();
            }
            else
            {
                ischarged = false;
            }

        }
    }
}
