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
        private Collider2D _box;

        public override Collider2D getCollider2D()
        {
            Debug.Log("GetCollider2D");
            Debug.Log(_box == null);
            return _box;
        }

        public override void init(string name, Animator anim, Transform transform, BoxCollider2D boxCollider2D, Rigidbody2D rigibody)
        {
            _box = boxCollider2D;
            Debug.Log("Work");
            Debug.Log(_box == null);
            base.init(name, anim, transform, boxCollider2D, rigibody);
            sprite = GetComponent<SpriteRenderer>();
        }

        public void Start()
        {
            Debug.Log("Door");
            init("Door", GetComponent<Animator>(), GetComponent<Transform>(), GetComponent<BoxCollider2D>(), GetComponent<Rigidbody2D>());
        }

        public void Update()
        {

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

