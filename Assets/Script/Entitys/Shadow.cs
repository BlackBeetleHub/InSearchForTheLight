using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script
{
    public class Human : Entity
    {
        protected new void init(string name, int x, int y, Animator animator)
        {
            base.init(name, x, y, animator);
        }
    }
}
