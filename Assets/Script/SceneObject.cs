﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script
{
    public abstract class SceneObject : MonoBehaviour, IUseable
    {
        private Rigidbody2D _rigibody;
        private BoxCollider2D _collider { set; get; }
        private Transform _transform;
        private Animator _animator;
        private string _name;
        private bool active = false; // StateObjectManager instend of bool

        public virtual BoxCollider2D getCollider2D()
        {
            return _collider;
        }

        public bool getStatus()
        {
            return active;
        }

        public SceneObject()
        {

        }

        public virtual void use(Entity entity)
        {
            active = !active;
            //GetComponent<SpriteRenderer>().enabled = active;
            // change Animator.
        }

        public virtual void init(string name, Animator anim, Transform transform, BoxCollider2D boxCollider2D, Rigidbody2D rigibody)
        {
            _name = name;
            _rigibody = rigibody;
            _transform = transform;
            _animator = anim;
            _collider = boxCollider2D;
        }

        public override string ToString()
        {
            return "SceneObject";
        }

    }

   
}
