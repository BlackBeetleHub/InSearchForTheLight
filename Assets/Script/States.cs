using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script
{

    public enum STATE
    {
        JUMPING,
        WALKING,
        SITTING,
        RUNNING,
        STAYING
    }

    public abstract class CharacterState
    {
        public abstract void handleInput(CharacterController character, Command command);
        public abstract void update(CharacterController character);
    }

    public class OnGroundState : CharacterState
    {
        public override void handleInput(CharacterController character, Command command)
        {
            if (command.ToString() == "StayCommand")
            {
                character._stateInput = new StayingStateCharacter();
                command.execute(character);
            }
            else if (command.ToString() == "WalkCommand")
            {
                character._stateInput = new WalkingStateCharacter();
                command.execute(character);
            }
            else if (command.ToString() == "RunCommand")
            {
                character._stateInput = new RunningStateCharacter();
                command.execute(character);
            } 
            if(character.getCurrentSpeedY() <= 0.1 && command.ToString() == "JumpCommand")
            {
                character._stateInput = new JumpingStateCharacter();
                command.execute(character);
            }
            if (command.ToString() == "UseCommand")
            {
                command.execute(character);
            }
           
            
        }
        public override void update(CharacterController character)
        {

        }
    }

    public class DuckingStateCharacter : OnGroundState
    {
        public override void handleInput(CharacterController character, Command command)
        {
            if (command.ToString() == "DuckCommand")
            {

            }
            else if (character._state != STATE.RUNNING && character._state != STATE.JUMPING)
            {
                character._state = STATE.SITTING;
            }
        }
        public override void update(CharacterController character)
        {

        }
    }

    public class JumpingStateCharacter : OnGroundState
    {
        public override void handleInput(CharacterController character, Command command)
        {
            if (character.getCurrentSpeedY() != 0)
            {
                character._stateInput = new JumpingStateCharacter();
                character.Down();
            }
            else
            {
                character._stateInput = new StayingStateCharacter();
                command.execute(character);
            }
        }

        public override void update(CharacterController human)
        {

        }
    }

    public class StayingStateCharacter : OnGroundState
    {
        public override void handleInput(CharacterController character, Command command)
        {
            base.handleInput(character, command);
        }

        public override void update(CharacterController human)
        {

        }
    }

    public class WalkingStateCharacter : OnGroundState
    {
        public override void handleInput(CharacterController character, Command command)
        {
            base.handleInput(character, command);
        }

        public override void update(CharacterController human)
        {

        }
    }

    public class RunningStateCharacter : OnGroundState
    {
        public override void handleInput(CharacterController character, Command command)
        {
            base.handleInput(character, command);
        }

        public override void update(CharacterController human)
        {

        }
    }
}
