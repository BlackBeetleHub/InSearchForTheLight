using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Script
{
    public struct Rect
    {
        private float _wigth;
        private float _hight;
        public float getWidth()
        {
            return _wigth;
        }
        public float getHight()
        {
            return _hight;
        }
        public Rect(float wigth, float hight)
        {
            _wigth = wigth;
            _hight = hight;
        }
    }

    interface ICamera
    {
        void setRect(Rect rect);
        void scale(int value);
        void following(Entity entity);
    }
}
