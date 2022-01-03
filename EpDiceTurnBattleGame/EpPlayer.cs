using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace EpDiceTurnBattleGame
{

    public class EpPlayer : EpUnit
    {
        public EpPlayer(Bitmap image, float x, float y, int life)
        {
            Bmp = image;
            Width = Bmp.Width;
            Height = Bmp.Height;

            X = x - Width / 2;
            Y = y - Height / 2;
            HP = life;
        }

        override public void Draw(Graphics g)
        {
            g.DrawImage(Bmp, X, Y);

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            g.DrawString("체력 : " + HP.ToString(), font, Brushes.Black, 225, 281, stringFormat);
            g.DrawString("체력 : " + HP.ToString(), font, Brushes.White, 225, 280, stringFormat);
        }

        public void SetHP(int hp)
        {
            this.HP -= hp;
        }

        public void SetHeal(int hp)
        {
            this.HP += hp;
        }
        public void ReSet(int hp)
        {
            this.HP = hp;
        }

        public void SetStat(int dice, int damage)
        {
            Atk = dice * damage;
            Dfd = dice * damage * 2;
        }

        public void move(float x)
        {
            if (X < x)
                X += 20;
        }

        public void moveBack(float x)
        {
            if (X >= x)
                X -= 20;
        }
    }
}
