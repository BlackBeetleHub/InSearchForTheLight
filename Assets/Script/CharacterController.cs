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

    void FixedUpdate()
    {
        Command command = Handle.inputHandler();
        _stateInput.handleInput(this, command);
    }

    void Update()
    {

    }
}
