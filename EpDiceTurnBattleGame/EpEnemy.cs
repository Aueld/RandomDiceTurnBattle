using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Media;

namespace EpDiceTurnBattleGame
{
    public class EpEnemy : EpUnit
    {


        private int fadeCount { get; set; }
        private bool isDesappeared = false;

        public bool IsDesappeared
        {
            get
            {
                return isDesappeared;
            }
        }
        
        public EpEnemy(Bitmap image, float x, float y, int hp)
        {
            Bmp = image;
            Width = Bmp.Width;
            Height = Bmp.Height;

            Bmp.MakeTransparent();
            
            HP = hp;
            X = x - Width / 2;
            Y = y - Height / 2;
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

        public void SetStat(int dice, int damage, int critical)
        {
            Atk = dice * damage;
            Dfd = dice * damage * 2;

            if (critical < 15)
            {
                Atk = (int)((float)Atk * 1.2f);
                Dfd = (int)((float)Dfd * 1.2f);
            }
        }

        override public void Draw(Graphics g)
        { 
            g.DrawImage(Bmp, X, Y);

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            g.DrawString("체력 : " + HP.ToString(), font, Brushes.Black, 675, 281, stringFormat);
            g.DrawString("체력 : " + HP.ToString(), font, Brushes.White, 675, 280, stringFormat);
        }

        public void Fade(Bitmap enemyImg, int scrollY)
        {
            for (int y = 0; y < Bmp.Height; y++)
            {
                for (int x = 0; x < Bmp.Width; x++)
                {
                    var tp = Bmp.GetPixel(0, Height - 1);
                    var p = Bmp.GetPixel(x, y);
                    if ((int)(this.X) + x < 0)
                        continue;

                    if ((int)(this.X) + x >= enemyImg.Width)
                        continue;

                    if ((int)(this.Y) + y - scrollY < 0)
                        continue;

                    if ((int)(this.Y) + y - scrollY >= enemyImg.Height)
                        continue;

                    var hp = enemyImg.GetPixel((int)(this.X) + x, (int)(this.Y) + y - scrollY);
                    //var cc = new ColorConverter();
                    var np = Color.FromArgb(p.R * (fadeCount - 1) / fadeCount + hp.R / fadeCount, p.G * (fadeCount - 1) / fadeCount + hp.G / fadeCount, p.B * (fadeCount - 1) / fadeCount + hp.B / fadeCount);
                    
                    if (p == tp)
                        continue;

                    Bmp.SetPixel(x, y, np);
                }
            }
            fadeCount--;

            if (fadeCount == 0)
                isDesappeared = true;

        }

        public void move(float x)
        {
            // X = 600

            if (X > x)
                X -= 20;
        }

        public void moveBack(float x)
        {
            // 600
            // 200

            if (X <= x)
                X += 20;
        }

        public bool IsFadeOut(int screenWidth, int screenHeight)
        {
            if (X >= screenWidth - 310) return true;
            if (X < -20 - Width / 2) return true;
            if (Y >= screenHeight + 20) return true;
            if (Y < -20 - Height / 2) return true;

            return false;
        }
    }
}
