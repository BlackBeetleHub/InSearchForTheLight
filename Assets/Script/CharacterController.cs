using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect: MonoBehaviour
{

}

public class Item : MonoBehaviour
{
    private int command;
    private Effect effect;
    private Animator anim;
    public virtual void execute(Entity entity)
    {
        anim.SetBool("animationName", true);
    }
}


public class Entity : MonoBehaviour
{
    protected int _health {
        set {
            if (value > 0 && value < _maxHealth) {
                _health = value;
             }
        }
        get {
            return _health;
        }
    }
    protected int _maxHealth = 100;
    protected int _maxSpeed = 5;
    public virtual void Attack()
    {
        _animator.SetBool("Attack", true);
    }
    public virtual void SpecialAttack()
    {
        _animator.SetBool("SpecialAttack", true);
    }
    public virtual void UseItemOnHand()
    {
        Item item = new Item(); // public class Tourch: Item { // } // Item item = new Tourch(); 
        item.execute(this);
    }
    public virtual void Walk()
    {
        _animator.SetBool("Grounded", true);
    }
    public virtual void Jump()
    {
        _animator.SetBool("Grounded", false);
    }
    public virtual void Run()
    {
        _animator.SetBool("SpecialAttack", true);
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
    protected Animator _animator{ set; get; }

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
    public void setAnimatorValueB(string animName, bool value)
    {
        _animator.SetBool(animName, value);
    }
    public void setAnimatorValueF(string animName, float value)
    {
        _animator.SetFloat(animName, value);
    }
    public void setAnimatorValueI(string animName, int value)
    {
        _animator.SetInteger(animName, value);
    }
}

public class CharacterController : Entity
{

    protected new void init(string name, int x, int y, Animator animator)
    {
        base.init(name, x, y, animator);
    }
    // Use this for initialization
    void Start () {
        init("Chatacter", 1, 2, GetComponent<Animator>());
    }

    void FixedUpdate()
    {
        float res = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        else
        {
            Walk();
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(res * _maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
    }
    // Update is called once per frame
    void Update () {
        
	}
}
