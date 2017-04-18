﻿using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterController : Human
{
    public CharacterState _stateInput;
    public STATE _state = STATE.STAYING;
    public InputHandler Handle;
    
    void Start()
    {
        Handle = new InputHandler();
        init("Chatacter", GetComponent<Animator>(), GetComponent<Transform>(), GetComponent<Rigidbody2D>());
        _stateInput = new StayingStateCharacter();
    }

    public override void walk()
    {
        Transform transform = GetComponent<Transform>();
        setSpeed(5);
        GetComponent<Rigidbody2D>().velocity = new Vector2(getSpeed(), GetComponent<Rigidbody2D>().velocity.y);
        base.walk();
    }

    void FixedUpdate()
    {
        Command command = Handle.inputHandler();
        _stateInput.handleInput(this, command);
        //setSpeed(Input.GetAxis("Horizontal"));
        //float res = Input.GetAxis("Horizontal");
        // GetComponent<Rigidbody2D>().velocity = new Vector2(res * _maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
