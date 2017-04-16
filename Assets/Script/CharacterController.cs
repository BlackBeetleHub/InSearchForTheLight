using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : Human
{
    void Start () {
        init("Chatacter", 1, 2, GetComponent<Animator>());
    }

    void FixedUpdate()
    {
        float res = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }
        else
        {
            walk();
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(res * _maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
    }
    // Update is called once per frame
    void Update () {
        
	}
}
