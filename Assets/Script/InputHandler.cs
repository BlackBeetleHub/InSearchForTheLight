﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script
{
    public interface Command
    {
        void execute(CharacterController gameActor);
    }

    class JumpCommand : Command
    {
        public void execute(CharacterController gameActor)
        {
            gameActor.jump();
        }
    }

    class WalkCommand : Command
    {
        public void execute(CharacterController gameActor)
        {
            gameActor.walk();
        }
    }

    class UseItemCommand : Command
    {
        public void execute(CharacterController gameActor)
        {
            gameActor.useItemOnHand();
        }
    }

    public class InputHandler
    {
        public Command inputHandler()
        {
            if (Input.GetKeyDown(KeyCode.W)) return new JumpCommand();
            if (Input.GetKeyDown(KeyCode.D)) return new WalkCommand();
            if (Input.GetKeyDown(KeyCode.A)) return new WalkCommand();
            if (Input.GetKeyDown(KeyCode.E)) return new UseItemCommand();
            return new WalkCommand();
        }
    }
}
