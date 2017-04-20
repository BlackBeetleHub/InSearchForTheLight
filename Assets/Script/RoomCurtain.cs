using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCurtain : MonoBehaviour {

    private bool Exiting;
    private bool Entering;
    private SpriteRenderer WallPict;
    private Color alpha;
    // Use this for initialization

    void Start () {
        Exiting = false;
        Entering = false;

        WallPict = gameObject.GetComponent<SpriteRenderer>();
        alpha = WallPict.color;
    }

    // Update is called once per frame
    void Update()
    {   
        if (Entering)
        {
            CurtainUp();
        }
        else if (Exiting)
        {
            CurtainDown();
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Entering = true;
            Exiting = false;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Exiting = true;
            Entering = false;
        }
    }
    private void CurtainUp()
    {

        if (alpha.a > 0.2f)
        {
            alpha.a -= (Time.deltaTime);
            alpha.a = Mathf.Clamp(alpha.a, 0.2f, 1);
            WallPict.color = alpha;
        }
        else
        {
            Entering = false;
        }

    }
    private void CurtainDown()
    {
        if (alpha.a < 1)
        {
            alpha.a += (Time.deltaTime);
            alpha.a = Mathf.Clamp(alpha.a, 0, 1);
            WallPict.color = alpha;
        }
        else
        {
            Exiting = false;
        }
    }

}
