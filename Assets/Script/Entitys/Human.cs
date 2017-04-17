using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script
{
    public class Human : Entity, IHumanActionable
    {
        public void useItemOnHand()
        {

        }

        public void talk(Entity entity)
        {

        }

        public void think()
        {

        }

        public void useObject()
        {

        }

        public void dropItemOnHand()
        {

        }

        protected new void init(string name, Animator animator, Transform transform, Rigidbody2D rigiBody)
        {
            base.init(name, animator, transform, rigiBody);
        }
    }
}
