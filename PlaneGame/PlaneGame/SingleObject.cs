using System.Collections.Generic;
using System.Drawing;

namespace PlaneGame
{
    internal class SingleObject
    {
        private SingleObject() { }//构造函数私有化
        private static SingleObject _singleobject = null;//全局唯一对象

        public static SingleObject GetSingle()//提供一个静态函数用于返回一个唯一的对象
        {
            if (_singleobject == null)
                _singleobject = new SingleObject();
            return _singleobject;
        }
        //单例设计完成



        /// <summary>
        /// 用属性存储背景对象
        /// </summary>
        public BackGround BG
        {
            get;
            set;
        }

        /// <summary>
        /// 属性存储玩家飞机
        /// </summary>
        public PlaneHero Hero
        {
            get;
            set;
        }
       


        //声明一个集合对象来存储玩家子弹
        public List<ZiDanHero> listHeroZiDan = new List<ZiDanHero>();

        //声明一个集合对象来存储敌人飞机对象
        public List<PlaneEnemy> listPlaneEnemy = new List<PlaneEnemy>();

        /// <summary>
        /// 将创建的游戏对象（背景）添加到窗体中
        /// </summary>
        /// <param name="go"></param>
        public void AddGameObject(GameObject go)//不确定要把谁添加到窗体中，所以用父类
        {
            if (go is BackGround)
                this.BG = (BackGround)go;//此处是把背景对象添加到窗体中，所以转换为子类对象
            else if (go is PlaneHero)
                this.Hero = (PlaneHero)go;
            else if (go is ZiDanHero)//将子弹对象添加到游戏当中
                listHeroZiDan.Add((ZiDanHero)go);
            else if (go is PlaneEnemy)
                listPlaneEnemy.Add((PlaneEnemy)go);
          
        }

        //绘制背景图像和其他对象
        public void DrawGameobject(Graphics g)//这只是在单例中实现了绘制函数，还要在窗体中调用这个函数进行绘制
        {
            this.BG.Draw(g);//绘制背景图像
            this.Hero.Draw(g);//绘制玩家飞机
            for (int i = 0; i < listHeroZiDan.Count; i++)//将子弹都封装成一个集合，然后再进行绘制
            {
                this.listHeroZiDan[i].Draw(g);
            }
            //绘制三种不同的敌人飞机
            for (int i = 0; i < listPlaneEnemy.Count; i++)
            {
                this.listPlaneEnemy[i].Draw(g);
            }
        }

      

        //从集合中移除
        public void RemoveGameObject(GameObject go)
        {
            if (go is PlaneEnemy)
                listPlaneEnemy.Remove(go as PlaneEnemy);
            else if (go is ZiDanHero)
                listHeroZiDan.Remove(go as ZiDanHero);
        }
    }
}