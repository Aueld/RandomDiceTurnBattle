using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace EpDiceTurnBattleGame
{
    class EpDice : GameManager
    {
        private Random Rand = new Random();

        private int DiceRand { get; set; }
        private int DiceDamage { get; set; }
        private int[] GetDiceResult = new int[3];

        public EpDice()
        {
            DiceRand = Rand.Next(5);
            DiceDamage = Rand.Next(20, 30) + 1;
        }

        private Bitmap GetDiceME()
        {
            DiceRand = Rand.Next(5);
            GetDiceResult[0] = DiceRand + 1;
            return Dice[DiceRand];
        }
        private Bitmap GetDiceEN()
        {
            DiceRand = Rand.Next(5);
            GetDiceResult[1] = DiceRand + 1;
            return Dice[DiceRand];
        }

        private int GetDamage()
        {
            DiceDamage = Rand.Next(20, 30) + 1;
            GetDiceResult[2] = DiceDamage;

            return DiceDamage;
        }

        public void DrawDiceME(Graphics g, float x, float y)
        {
            g.DrawImage(GetDiceME(), x - 25, y - 100, 50, 50);
        }

        public void DrawDiceEN(Graphics g, float x, float y)
        {
            g.DrawImage(GetDiceEN(), x - 25, y - 100, 50, 50);
        }


        public void DrawDamage(Graphics g, float x, float y)
        {
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            g.DrawString(GetDamage().ToString(), font, Brushes.White, x, y, stringFormat);
        }

        public int[] GetResult()
        {
            return GetDiceResult;
        }
    }
}
