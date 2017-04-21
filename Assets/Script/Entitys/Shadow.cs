using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script
{
    public class Shadow : Entity
    {
        protected new void init(string name, Animator animator, Transform transform, Rigidbody2D rigiBody, BoxCollider2D collider2D)
        {
            base.init(name, animator, transform, rigiBody,collider2D);
        }
    }
}
