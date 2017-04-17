﻿using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterController : Human
{
    private bool running;
    private bool hidding;
    private bool staying;
    private bool jumping;
    public CharacterState _stateInput;
    public STATE _state = STATE.STAYING;
    public InputHandler Handle;
    private float flip = 0;
    void Start()
    {
        Handle = new InputHandler();
        init("Chatacter", 0, 0, GetComponent<Animator>());
        _state = STATE.STAYING;
        _stateInput = new StayingStateCharacter();
    }

    public override void walk()
    {
        
        GetComponent<Rigidbody2D>().velocity = new Vector2(flip * _maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        base.walk();
    }

    void FixedUpdate()
    {
        Command command = Handle.inputHandler();
        _stateInput.handleInput(this, command);
        flip = Input.GetAxis("Horizontal");
        //float res = Input.GetAxis("Horizontal");
        // GetComponent<Rigidbody2D>().velocity = new Vector2(res * _maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
