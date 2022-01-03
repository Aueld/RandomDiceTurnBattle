using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace EpDiceTurnBattleGame
{
    public class EpUnit
    {
        public int HP { get; set; }
        public int Atk { get; set; }
        public int Dfd { get; set; }
        public int RandomNum { get; set; }

        protected Bitmap Bmp { get; set; }

        public float X { get; set; }
        public float Y { get; set; }
        protected int Width { get; set; }
        protected int Height { get; set; }



        protected Font font = new System.Drawing.Font("맑은 고딕", 15);
        public float getX
        {
            get
            {
                return X;
            }
        }
        public float getY
        {
            get
            {
                return Y;
            }
        }


        virtual public void Draw(Graphics g) { }
    }
}
