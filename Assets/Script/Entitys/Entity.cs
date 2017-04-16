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
            _animator.SetBool("Walking", true);
            _animator.SetBool("Jumping", false);
            _animator.SetBool("Running", false);

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
        protected virtual void init(string name, int x, int y, Animator animator)
        {
            _name = name;
            _health = _maxHealth;
            _x = x;
            _y = y;
            _animator = animator;
        }
        public override string ToString()
        {
            return _name;
        }
    }
}
