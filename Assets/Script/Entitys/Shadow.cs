using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script
{
    public class Shadow : Entity
    {
        protected new void init(string name, Animator animator, Transform transform, Rigidbody2D rigiBody)
        {
            base.init(name, animator, transform, rigiBody);
        }
    }
}
