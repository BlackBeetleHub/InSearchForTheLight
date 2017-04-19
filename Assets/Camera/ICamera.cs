using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Script
{
    struct Rect
    {
        int wigth;
        int hight;
    }

    interface ICamera
    {
        void setRect(Rect rect);
        void scale(int value);
        void following(Entity entity);
    }
}
