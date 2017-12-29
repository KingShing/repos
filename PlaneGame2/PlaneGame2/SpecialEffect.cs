using PlaneGame2.Resources;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PlaneGame2
{
    internal class SpecialEffect:Element

    {
   
        public SpecialEffect(Image image, int x, int y, int speed) : base (image ,x,y,speed){
            
        }
        static SpecialEffect New(int x,int y) {
            return new SpecialEffect(Util.Fire_8_8, x, y, 5);
        }
        public void Update() {
            this.X += Util.GetUtilInstance().Random.Next(-10, 10);
            this.Y += Util.GetUtilInstance().Random.Next(-10, 10);
        }

     
        
    }
}