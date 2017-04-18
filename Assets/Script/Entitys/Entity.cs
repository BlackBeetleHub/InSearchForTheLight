using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script
{
    public class Entity : MonoBehaviour, IActionable
    {
        protected int _health
        {
            set
            {
                if (value > 0 && value < _maxHealth)
                {
                    _health = value;
                }
            }
            get
            {
                return _health;
            }
        }
        protected int _maxHealth = 100;
        protected int _maxSpeed = 15;
        private Transform _transform;
        private Rigidbody2D _rigiBody;
        private bool isFlip = false; //Rignt
        public void setSpeed(float value)
        {
            if (isFlip)
            {
                speed = value * -1;
            }
            else
            {
                speed = value;
            }

        }
        public float getSpeed()
        {
            return speed;
        }
        public float speed = 5;
        public virtual void sit()
        {
            _animator.SetBool("Sit", true);
        }

        public virtual void attack(Entity entity)
        {
            _animator.SetBool("Attack", true);
        }
        public virtual void specialAttack()
        {
            _animator.SetBool("SpecialAttack", true);
        }
        public virtual void walk()
        {
            //setSpeed(5);
            _animator.SetBool("Walking", true);
            _animator.SetBool("Staying", false);

        }

        public void flip(bool value) // will be future optimazied
        {
            if (value == isFlip)
            {
                return;
            }
            isFlip = value;
            Vector3 vec = transform.localScale;
            vec.x *= -1;
            transform.localScale = vec;
        }

        public virtual void stay()
        {
            //setSpeed(0);
            _rigiBody.velocity = new Vector2(0, _rigiBody.velocity.y);
            _animator.SetBool("Walking", false);
            _animator.SetBool("Staying", true);

        }
        public virtual void jump()
        {
            _animator.SetBool("Grounded", false);
        }
        public virtual void run()
        {
            _animator.SetBool("SpecialAttack", true);
        }
        public virtual void executeCommand()
        {

        }
        public virtual void getHit(int value)
        {
            _health -= value;
        }
        public void setHealth(int value)
        {
            _health = value;
        }
        protected int _x { set; get; }
        protected int _y { set; get; }
        protected Animator _animator { set; get; }

        private string _name;


        void bindAnimator(Animator animator)
        {
            _animator = animator;
        }
        protected virtual void init(string name, Animator animator, Transform transform, Rigidbody2D rigiBody)
        {
            _name = name;
            _health = _maxHealth;
            _animator = animator;
            _transform = transform;
            _rigiBody = rigiBody;
        }
        public override string ToString()
        {
            return _name;
        }


    }
}
