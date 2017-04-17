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
        protected int _maxSpeed = 5;
        private Transform _transform;
        private Rigidbody2D _rigiBody;
        private bool isFlip = false; //Rignt
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
            float xVelocity = _rigiBody.velocity.x;
            if ( xVelocity < 0 && !isFlip)
            {
                isFlip = true;
                Vector3 vec = transform.localScale;
                vec.x *= -1;
                transform.localScale = vec;
            }else if (xVelocity > 0 && isFlip)
            {
                isFlip = false;
                Vector3 vec = transform.localScale;
                vec.x *= -1;
                transform.localScale = vec;
            }
            _animator.SetBool("Walking", true);
            _animator.SetBool("Staying", false);

        }
        public virtual void stay()
        {

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
