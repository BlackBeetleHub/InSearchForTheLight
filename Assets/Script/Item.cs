using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script
{
    public class Item : MonoBehaviour
    {
        private Effect _effect;
        private Animator _anim;
        private string _name;
        
        public Item(string name, Animator anim, Effect effect = null)
        {
            _name = name;
            _anim = anim;
            _effect = effect;
        }

        public virtual void use(Entity entity) { ; }
    }
}
