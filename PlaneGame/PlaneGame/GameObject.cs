using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneGame
{
    abstract class GameObject
    {
        public enum Direction
        {
            Up, Down, Right, Left
        }
        public int X
        {
            get;
            set;
        }
        public int Y
        {
            get;
            set;
        }
        public int Width
        {
            set;
            get;
        }
        public int Height
        {
            set;
            get;
        }
        public int Speed
        {
            set;
            get;
        }
        public int Life
        {
            set;
            get;
        }
        public Direction Dir
        {
            set;
            get;
        }

        
        public GameObject(int x, int y, int width, int height, int speed, int life, Direction dir)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.Life = life;
            this.Speed = speed;
            this.Dir = dir;
        }

        //绘制对象
        public abstract void Draw(Graphics g);
       
        //用于碰撞检测
        public Rectangle GetRectangle()
        {
            return new Rectangle(this.X, this.Y, this.Width, this.Height);
        }
        

        //移动
        public virtual void Move()
        {
            switch (Dir)
            {
                case Direction.Up:
                    this.Y -= this.Speed;
                    break;
                case Direction.Down:
                    this.Y += this.Speed;
                    break;
                case Direction.Left:
                    this.Width -= this.Speed;
                    break;
                case Direction.Right:
                    this.Height += this.Speed;
                    break;
            }

            //移动结束之后，判断飞机与窗体之间的关系，敌机会重写此方法不管
            if (this.X < 0)
                this.X = 0;
            if (this.X > 480)
                this.X = 400;
            if (this.Y <= 0)
                this.Y = 0;
            if (this.Y >= 720)
                this.Y = 720;
        }
    }
}
