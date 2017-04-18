using System;
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

        public override string ToString()
        {
            return "JumpCommand";
        }
    }

    class WalkCommand : Command
    {
        public void execute(CharacterController gameActor)
        {

            gameActor.flip(InputHandler.isFlip);
            gameActor.walk();
        }

        public override string ToString()
        {
            return "WalkCommand";
        }
    }

    class UseItemCommand : Command
    {
        public void execute(CharacterController gameActor)
        {
            gameActor.useItemOnHand();
        }
    }

    class StayCommand : Command
    {
        public void execute(CharacterController gameActor)
        {
            gameActor.stay();
        }
        public override string ToString()
        {
            return "StayCommand";
        }
    }

    public class InputHandler
    {
        public static bool isFlip = false;

        public Command inputHandler()
        {
            if (Input.GetButtonDown("Jump"))
            {
                return new JumpCommand();
            }

            if (Input.GetKey(KeyCode.D))
            {
                isFlip = false;
                return new WalkCommand();

            }

            if (Input.GetKey(KeyCode.A))
            {
                isFlip = true;
                return new WalkCommand();
            }

            return new StayCommand();
        }
    }
}
