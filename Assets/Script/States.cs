using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script
{

    public enum STATE{
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

    public class DuckingStateCharacter : CharacterState
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

    public class JumpingStateCharacter : CharacterState
    {
        public override void handleInput(CharacterController character, Command command)
        {
            if (command.ToString() == "JumpCommand" && character._state != STATE.JUMPING && character._state != STATE.SITTING)
            {

                character._state = STATE.JUMPING;
                command.execute(character);
            }
        }

        public override void update(CharacterController human)
        {

        }
    }

    public class StayingStateCharacter : CharacterState
    {
        public override void handleInput(CharacterController character, Command command)
        {
            //Debug.Log("command.ToString()");
            if (command.ToString() == "StayCommand")
            {
                character._stateInput = new StayingStateCharacter();
                Debug.Log("Stay");
                command.execute(character);
            }else if(command.ToString() == "WalkCommand")
            {
                character._stateInput = new WalkingStateCharacter();
                
                command.execute(character);
            }
        }

        public override void update(CharacterController human)
        {

        }
    }

    public class WalkingStateCharacter : CharacterState
    {
        public override void handleInput(CharacterController character, Command command)
        {
            if (command.ToString() == "StayCommand")
            {
                character._stateInput = new StayingStateCharacter();
                Debug.Log("Stay");
                command.execute(character);
            }
            else if (command.ToString() == "WalkCommand")
            {
                character._stateInput = new WalkingStateCharacter();

                command.execute(character);
            }
        }

        public override void update(CharacterController human)
        {

        }
    }
}
