using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script
{
    public class Entity : MonoBehaviour, IActionable
    {
        // Refactoring !!!
        public delegate void useObject(Entity entity);
        public event useObject eventUseObject;

        protected int _maxHealth = 100;
        protected int _maxSpeed = 15;
        private int MAX_WALK_SPEED = 4;
        private int MAX_RUN_SPEED = 7;
        private bool isFlip = false; //Rignt
        private float speed = 5;
        private Transform _transform;
        private Rigidbody2D _rigiBody;
        private BoxCollider2D _collider;
        private string _name;
        public CharacterState _stateInput;
        public STATE _state = STATE.STAYING;
        public BoxCollider2D getCollider2D() {
            return _collider;
        }
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

        public float getCurrentSpeedX()
        {
            return _rigiBody.velocity.x;
        }

        public float getSpeed()
        {
            return speed;
        }
       
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
        public virtual void run()
        {
            setSpeed(MAX_RUN_SPEED);
            _rigiBody.velocity = new Vector2(getSpeed(), _rigiBody.velocity.y);
            _animator.SetBool("Walking", false);
            _animator.SetBool("Staying", false);
            _animator.SetBool("Running", true);
        }
        public virtual void walk()
        {
            
            setSpeed(MAX_WALK_SPEED); // MAX_WALK_SPEED  =  4
            _rigiBody.velocity = new Vector2(getSpeed(), _rigiBody.velocity.y);
            _animator.SetBool("Walking", true);
            _animator.SetBool("Staying", false);
            _animator.SetBool("Running", false);

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
            _animator.SetBool("Running", false);
        }
        public virtual void jump()
        {
            _animator.SetBool("Grounded", false);
        }
        
        public virtual void executeCommand()
        {

        }
        public virtual void getHit(int value)
        {
            _health -= value;
        }

        public void useObjectOnScane()
        {
            Debug.Log("Event useObjectOnScane");
            eventUseObject(this);
        }

        public void setHealth(int value)
        {
            _health = value;
        }
        protected Animator _animator { set; get; }

        void bindAnimator(Animator animator)
        {
            _animator = animator;
        }
        protected virtual void init(string name, Animator animator, Transform transform, Rigidbody2D rigiBody, BoxCollider2D collider2D)
        {
            _name = name;
            _health = _maxHealth;
            _animator = animator;
            _transform = transform;
            _rigiBody = rigiBody;
            _collider = collider2D;
        }
        public override string ToString()
        {
            return _name;
        }
    }
}
