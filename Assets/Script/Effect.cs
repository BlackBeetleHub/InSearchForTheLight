using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script
{
    public abstract class Effect
    {
        private string _name;

        public abstract void activate(Entity entity);
        public abstract void deactivate();

        public Effect(string name)
        {
            _name = name;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
