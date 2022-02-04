using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Media;

namespace EpDiceTurnBattleGame
{
    public class GameManager : Form
    {
        protected Graphics g;
        protected Bitmap bmp;
        protected static Bitmap enemyImg;// = Properties.Resources.Enemy;
        protected static Bitmap playerImg;

        protected static SoundPlayer stageSound1;
        protected static SoundPlayer stageSound2;
        protected static SoundPlayer mainSound;
        protected static SoundPlayer enemyDie;

        protected static Bitmap background;
        protected static Bitmap buttonStart;
        protected static Bitmap buttonExit;
        protected static Bitmap mainBack;
        protected static Bitmap Attack;
        protected static Bitmap Shield;
        protected static Bitmap Magic;
        protected static Bitmap Roll;
        protected static Bitmap Run;

        protected static List<Bitmap> Dice = new List<Bitmap>();

        protected static Font font;

        protected bool gameOver = false;
        protected bool bossStage = false;
        protected bool deadly = false;
        protected bool timeCheck = false;
        protected bool gameStart = false;
        protected bool loop = false;
        protected bool check = false;
        protected bool turnCheck = false;

        protected bool TurnRoll = false;
        protected bool RollDice = false;
        protected bool TurnEnd = false;

        protected float imageSize { get; set; }

        protected int panelWidth { get; set; }
        protected int panelHeight { get; set; }
        protected int playerHp { get; set; }
        protected int enemyHp { get; set; }
        protected int bossHp { get; set; }
        protected int curtain { get; set; }
        protected int ActionState { get; set; }

        protected int state;      // 0 = 공공, 1 = 방공, 2 = 공방, 3 = 방방, 4 = 마법 // (0 = 0, 0), (1 = 1, 0), (2 = 0, 1), (3 = 1, 1), (4 = 3) 
        protected int stateAI;    // 0 = 공공, 1 = 방공, 2 = 공방, 3 = 방방, 4 = 마법 // (0 = 0, 0), (1 = 1, 0), (2 = 0, 1), (3 = 1, 1), (4 = 3)
        protected int round;
        protected int time;

        protected float playerX;
        protected float enemyX;

        protected bool moveCheck;
        protected bool enemyMoveCheck;
        protected bool enemyTurn;

        protected bool playerAtk;
        protected bool playerDfd;
        protected bool enemyAtk;
        protected bool enemyDfd;
        protected bool playerMag;
        protected bool enemyMag;
        protected bool firstRoll;

        protected Point point = new Point();

        protected static EpPlayer player;
        protected static EpEnemy enemy;

        protected static Rectangle StartButton;
        protected static Rectangle ExitButton;

        protected static Rectangle RollButton;
        protected static Rectangle RunButton;

        static GameManager() // new 다 여기로 뺼것
        {
            playerImg = Properties.Resources.Player;
            enemyImg = Properties.Resources.Enemy;

            stageSound1 = new SoundPlayer(Properties.Resources.Dube);
            stageSound2 = new SoundPlayer(Properties.Resources.rain);
            mainSound = new SoundPlayer(Properties.Resources.menu);
            enemyDie = new SoundPlayer(Properties.Resources.die);
            background = Properties.Resources.Backk;
            buttonStart = Properties.Resources.BStart;
            buttonExit = Properties.Resources.BEXIT;
            mainBack = Properties.Resources.spaceMainBack;
            Roll = Properties.Resources.Roll;
            Run = Properties.Resources.Run;
            Attack = Properties.Resources.Attack;
            Shield = Properties.Resources.Shield;
            Magic = Properties.Resources.Magic;


            StartButton = new Rectangle(900 / 2 - buttonStart.Width / 4, 280, 150, 50);
            ExitButton = new Rectangle( 450 - buttonStart.Width / 4, 410, 150, 50);
            RollButton = new Rectangle(450 - Roll.Width / 2, 0, Roll.Width, Roll.Height);
            RunButton = new Rectangle(800, 250, 50, 50);

            Dice.Add(Properties.Resources.Dice1);
            Dice.Add(Properties.Resources.Dice2);
            Dice.Add(Properties.Resources.Dice3);
            Dice.Add(Properties.Resources.Dice4);
            Dice.Add(Properties.Resources.Dice5);
            Dice.Add(Properties.Resources.Dice6);

            font = new System.Drawing.Font("맑은 고딕", 30);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // GameManager
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "GameManager";
            this.Load += new System.EventHandler(this.GameManager_Load);
            this.ResumeLayout(false);

        }

        private void GameManager_Load(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
