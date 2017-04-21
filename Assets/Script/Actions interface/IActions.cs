using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Script
{
    public interface IActionable
    {
        void walk();
        void sit();
        void run();
        void attack(Entity entity);
        void jump();
        void stay();
        void getHit(int value);
        void specialAttack();
        void executeCommand();
        void useObjectOnScane();
    }

    public interface IDarkActionable : IActionable
    {
        void Hide();
    }

    public interface IHumanActionable : IActionable
    {
        void useItemOnHand();
        void dropItemOnHand();
        
        void think();
        void talk(Entity entity);
    }
}
