using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script
{
    public class Door : SceneObject
    {
        private SpriteRenderer sprite;
        private BoxCollider2D _box;

        public override BoxCollider2D getCollider2D()
        {
            return _box;
        }

        public override void init(string name, Animator anim, Transform transform, BoxCollider2D boxCollider2D, Rigidbody2D rigibody)
        {
            _box = boxCollider2D;
            base.init(name, anim, transform, boxCollider2D, rigibody);
            sprite = GetComponent<SpriteRenderer>();
        }

        public void Start()
        {
            init("Door", GetComponent<Animator>(), GetComponent<Transform>(), GetComponent<BoxCollider2D>(), GetComponent<Rigidbody2D>());
        }

        public override string ToString()
        {
            return "Door";
        }

        public override void use(Entity entity) // use(Entity)
        {
            base.use(entity);
            sprite.enabled = getStatus();
            //Debug.Log(getStatus());
            _box.isTrigger = getStatus();
        }
    }
}

