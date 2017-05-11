using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script
{
    public class TeleportDoor : Door
    {
        public float x;
        public float y;

        public override void init(string name, Animator anim, Transform transform, BoxCollider2D boxCollider2D, Rigidbody2D rigibody)
        {
            base.init(name, anim, transform, boxCollider2D, rigibody);
            //sprite = GetComponent<SpriteRenderer>();
        }

        public new void Start()
        {
            init("Door", GetComponent<Animator>(), GetComponent<Transform>(), GetComponent<BoxCollider2D>(), GetComponent<Rigidbody2D>());

        }

        public override void use(Entity entity)
        {
            entity.transform.position = new Vector2(x, y);
        }

        public void OnTriggerStay(Collider other)
        {
            // if (gameobject == Character)
            //state = true;
        }

        public void OnTriggerExit(Collider other)
        {
            // state = false; 
        }

        public override string ToString()
        {
            return "TeleportDoor";
        }
    }
}
