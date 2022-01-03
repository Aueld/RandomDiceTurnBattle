using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Timers;
using System.Media;

namespace EpDiceTurnBattleGame
{
    public partial class Form1 : GameManager
    {
        Random patten = new Random();
        EpDice dice = new EpDice();

        public void Start()
        {
            TurnRoll = false;
            RollDice = false;
            TurnEnd = false;

            moveCheck = false;
            enemyMoveCheck = false;
            enemyTurn = false;

            playerAtk = false;
            playerDfd = false;
            playerMag = false;
            enemyAtk = false;
            enemyDfd = false;
            enemyMag = false;
            time = 10;

            round = 0;
            ActionState = 0;

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
           
            panelWidth = panel.Width;
            panelHeight = panel.Height;

            playerHp = 1000;
            enemyHp = 1000;

            panel1.Visible = false;

            player = new EpPlayer(playerImg, 225, 200, playerHp);
            enemy = new EpEnemy(enemyImg, 675, 200, enemyHp);

            playerX = player.X;
            enemyX = enemy.X;

            bmp = new Bitmap(panelWidth, panelHeight);
            g = Graphics.FromImage(bmp);

            //mainSound.Play();
        }

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Start();
        }

        // 그림 처리
        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            if (gameStart)
            {
                panel1.Visible = true;
                e.Graphics.DrawImage(mainBack, 0, 0, 900, 540);

                player.Draw(e.Graphics);
                enemy.Draw(e.Graphics);


                if (playerAtk)
                    e.Graphics.DrawImage(Attack, enemy.X - 50, 150);
                if (enemyAtk)
                    e.Graphics.DrawImage(Attack, player.X + 50, 150);

                if (playerDfd)
                    e.Graphics.DrawImage(Shield, player.X + 50, 150);
                if (enemyDfd)
                    e.Graphics.DrawImage(Shield, enemy.X - 50, 150);

                if (playerMag)
                    e.Graphics.DrawImage(Magic, enemy.X - 50, 150);
                if (enemyMag)
                    e.Graphics.DrawImage(Magic, player.X + 50, 150);


                if (TurnRoll)
                {
                    TurnSetDice(e.Graphics);
                    TurnRoll = false;
                }

                GUIView(e);

                //e.Graphics.DrawImage(GUI, 84, 0);
            }
            else
            {
                e.Graphics.DrawImage(mainBack, -imageSize, -imageSize, 1400, 700 + imageSize);
                e.Graphics.DrawImage(buttonStart, StartButton);
                e.Graphics.DrawImage(buttonExit, ExitButton);
            }
        }

        // 애니메이션 타이머 동작
        private void RunAnimation(object sender, EventArgs e)
        {
            switch (ActionState)
            {
                case 1: // 공공공공

                    if (!enemyTurn)
                    {
                        if (!moveCheck)
                            player.move(playerX + 300);

                        if (player.X > playerX + 260)
                        {
                            playerAtk = true;
                            moveCheck = true;
                        }

                        if (moveCheck)
                            player.moveBack(playerX);

                        if (moveCheck && player.X <= playerX)
                        {
                            playerAtk = false;
                            enemyTurn = true;
                        }
                    }

                    else if (enemyTurn)
                    {
                        if(!enemyMoveCheck)
                            enemy.move(enemyX - 300);

                        if (enemy.X < enemyX - 260)
                        {
                            enemyAtk = true;
                            enemyMoveCheck = true;
                        }

                        if(enemyMoveCheck)
                            enemy.moveBack(enemyX);

                        if (enemyTurn && enemy.X >= enemyX)
                        {
                            enemyAtk = false;
                            enemyTurn = false;
                            round = 2;
                        }
                    }

                    if (!enemyTurn && moveCheck && enemyMoveCheck && round == 2)
                    {
                        moveCheck = false;
                        enemyMoveCheck = false;
                        round = 0;
                        ActionState = 0;
                    }

                    Invalidate();

                    break;
                case 2: // 공공 방공
                    if (round == 0)
                    {
                        if (!enemyTurn)
                        {
                            if (!moveCheck)
                                player.move(playerX + 300);

                            if (player.X > playerX + 260)
                            {
                                playerAtk = true;
                                enemyDfd = true;
                                moveCheck = true;
                            }

                            if (moveCheck)
                                player.moveBack(playerX);

                            if (moveCheck && player.X <= playerX)
                            {
                                playerAtk = false;
                                enemyDfd = false;
                                enemyTurn = true;
                            }
                        }

                        else if (enemyTurn)
                        {
                            if (enemyTurn && enemy.X >= enemyX)
                            {
                                enemyAtk = false;
                                enemyTurn = false;
                                moveCheck = false;
                                enemyMoveCheck = false;
                                round = 1;
                            }

                        }
                    }

                    if(round == 1)
                    {
                        if (!enemyTurn)
                        {
                            if (!moveCheck)
                                player.move(playerX + 300);

                            if (player.X > playerX + 260)
                            {
                                playerAtk = true;
                                moveCheck = true;
                            }

                            if (moveCheck)
                                player.moveBack(playerX);

                            if (moveCheck && player.X <= playerX)
                            {
                                playerAtk = false;
                                enemyTurn = true;
                            }
                        }

                        else if (enemyTurn)
                        {
                            if (!enemyMoveCheck)
                                enemy.move(enemyX - 300);

                            if (enemy.X < enemyX - 260)
                            {
                                enemyAtk = true;
                                enemyMoveCheck = true;
                            }

                            if (enemyMoveCheck)
                                enemy.moveBack(enemyX);

                            if (enemyTurn && enemy.X >= enemyX)
                            {
                                enemyAtk = false;
                                enemyTurn = false;
                                round = 2;
                            }
                        }

                        if (!enemyTurn && moveCheck && enemyMoveCheck && round == 2)
                        {
                            moveCheck = false;
                            enemyMoveCheck = false;
                            round = 0;
                            ActionState = 0;
                        }
                    }
                    Invalidate();

                    break;


                case 3: // 공공 공방
                    if (round == 0)
                    {
                        if (!enemyTurn)
                        {
                            if (!moveCheck)
                                player.move(playerX + 300);

                            if (player.X > playerX + 260)
                            {
                                playerAtk = true;
                                moveCheck = true;
                            }

                            if (moveCheck)
                                player.moveBack(playerX);

                            if (moveCheck && player.X <= playerX)
                            {
                                playerAtk = false;
                                enemyTurn = true;
                            }
                        }

                        else if (enemyTurn)
                        {
                            if (!enemyMoveCheck)
                                enemy.move(enemyX - 300);

                            if (enemy.X < enemyX - 260)
                            {
                                enemyAtk = true;
                                enemyMoveCheck = true;
                            }

                            if (enemyMoveCheck)
                                enemy.moveBack(enemyX);

                            if (enemyTurn && enemy.X >= enemyX)
                            {
                                enemyAtk = false;
                                enemyTurn = false;
                                moveCheck = false;
                                enemyMoveCheck = false;
                                round = 1;
                            }
                        }
                    }

                    if (round == 1)
                    {
                        if (!enemyTurn)
                        {
                            if (!moveCheck)
                                player.move(playerX + 300);

                            if (player.X > playerX + 260)
                            {
                                playerAtk = true;
                                enemyDfd = true;
                                moveCheck = true;
                            }

                            if (moveCheck)
                                player.moveBack(playerX);

                            if (moveCheck && player.X <= playerX)
                            {
                                playerAtk = false;
                                enemyDfd = false;
                                enemyTurn = true;
                            }
                        }

                        else if (enemyTurn)
                        {
                            if (enemyTurn && enemy.X >= enemyX)
                            {
                                enemyAtk = false;
                                enemyTurn = false;
                                enemyMoveCheck = true;
                                round = 2;
                            }

                        }

                        if (!enemyTurn && moveCheck && enemyMoveCheck && round == 2)
                        {
                            moveCheck = false;
                            enemyMoveCheck = false;
                            round = 0;
                            ActionState = 0;
                        }
                    }
                    Invalidate();
                    break;

                case 4: // 공공 방방
                    if (round == 0)
                    {
                        if (!enemyTurn)
                        {
                            if (!moveCheck)
                                player.move(playerX + 300);

                            if (player.X > playerX + 260)
                            {
                                playerAtk = true;
                                enemyDfd = true;
                                moveCheck = true;
                            }

                            if (moveCheck)
                                player.moveBack(playerX);

                            if (moveCheck && player.X <= playerX)
                            {
                                playerAtk = false;
                                enemyDfd = false;
                                enemyTurn = true;
                            }
                        }

                        else if (enemyTurn)
                        {
                            moveCheck = false;
                            enemyTurn = false;
                            round = 1;
                        }
                    }

                    if (round == 1)
                    {
                        if (!enemyTurn)
                        {
                            if (!moveCheck)
                                player.move(playerX + 300);

                            if (player.X > playerX + 260)
                            {
                                playerAtk = true;
                                enemyDfd = true;
                                moveCheck = true;
                            }

                            if (moveCheck)
                                player.moveBack(playerX);

                            if (moveCheck && player.X <= playerX)
                            {
                                playerAtk = false;
                                enemyDfd = false;
                                enemyTurn = true;
                            }
                        }
                        else if (enemyTurn)
                        {
                            round = 2;
                            enemyTurn = false;
                            enemyMoveCheck = true;
                        }

                        if (!enemyTurn && moveCheck && enemyMoveCheck && round == 2)
                        {
                            moveCheck = false;
                            enemyMoveCheck = false;
                            round = 0;
                            ActionState = 0;
                        }
                    }
                    Invalidate();

                    break;

                case 5: // 공공 마
                    if (!enemyTurn)
                    {
                        if (!moveCheck)
                            player.move(playerX + 300);

                        if (player.X > playerX + 260)
                        {
                            playerAtk = true;
                            moveCheck = true;
                        }

                        if (moveCheck)
                            player.moveBack(playerX);

                        if (moveCheck && player.X <= playerX)
                        {
                            playerAtk = false;
                            enemyTurn = true;
                            round = 2;
                        }
                    }

                    if (enemyTurn && moveCheck && round == 2)
                    {
                        enemyTurn = false;
                        moveCheck = false;
                        enemyMoveCheck = false;
                        round = 0;
                        ActionState = 0;
                    }

                    Invalidate();

                    break;

                case 6: // 방공공공
                    if (round == 0)
                    {
                        if (!enemyTurn)
                        {
                            enemyTurn = true;
                        }

                        else if (enemyTurn)
                        {
                            if (!enemyMoveCheck)
                                enemy.move(enemyX - 300);

                            if (enemy.X < enemyX - 260)
                            {
                                enemyAtk = true;
                                playerDfd = true;
                                enemyMoveCheck = true;
                            }

                            if (enemyMoveCheck)
                                enemy.moveBack(enemyX);

                            if (enemyTurn && enemy.X >= enemyX)
                            {
                                enemyAtk = false;
                                playerDfd = false;

                                enemyTurn = false;
                                moveCheck = false;
                                enemyMoveCheck = false;
                                round = 1;
                            }
                        }
                    }

                    if (round == 1)
                    {
                        if (!enemyTurn)
                        {
                            if (!moveCheck)
                                player.move(playerX + 300);

                            if (player.X > playerX + 260)
                            {
                                playerAtk = true;
                                moveCheck = true;
                            }

                            if (moveCheck)
                                player.moveBack(playerX);

                            if (moveCheck && player.X <= playerX)
                            {
                                playerAtk = false;
                                enemyTurn = true;
                            }
                        }

                        else if (enemyTurn)
                        {
                            if (!enemyMoveCheck)
                                enemy.move(enemyX - 300);

                            if (enemy.X < enemyX - 260)
                            {
                                enemyAtk = true;
                                enemyMoveCheck = true;
                            }

                            if (enemyMoveCheck)
                                enemy.moveBack(enemyX);

                            if (enemyTurn && enemy.X >= enemyX)
                            {
                                enemyAtk = false;
                                playerDfd = false;

                                enemyTurn = false;
                                round = 2;
                            }
                        }

                        if (!enemyTurn && moveCheck && enemyMoveCheck && round == 2)
                        {
                            enemyAtk = false;
                            moveCheck = false;
                            enemyMoveCheck = false;
                            round = 0;
                            ActionState = 0;
                        }
                    }
                    
                    Invalidate();
                    break;

                case 7: // 방공방공

                    if (!enemyTurn)
                    {
                        if (!moveCheck)
                            player.move(playerX + 300);

                        if (player.X > playerX + 260)
                        {
                            playerAtk = true;
                            moveCheck = true;
                        }

                        if (moveCheck)
                            player.moveBack(playerX);

                        if (moveCheck && player.X <= playerX)
                        {
                            playerAtk = false;
                            enemyTurn = true;
                        }
                    }

                    else if (enemyTurn)
                    {
                        if (!enemyMoveCheck)
                            enemy.move(enemyX - 300);

                        if (enemy.X < enemyX - 260)
                        {
                            enemyAtk = true;
                            enemyMoveCheck = true;
                        }

                        if (enemyMoveCheck)
                            enemy.moveBack(enemyX);

                        if (enemyTurn && enemy.X >= enemyX)
                        {
                            enemyAtk = false;
                            enemyTurn = false;
                            round = 2;
                        }
                    }

                    if (!enemyTurn && moveCheck && enemyMoveCheck && round == 2)
                    {
                        moveCheck = false;
                        enemyMoveCheck = false;
                        round = 0;
                        ActionState = 0;
                    }

                    Invalidate();
                    break;

                case 8: // 방공 공방
                    if (round == 0)
                    {
                        if (!enemyTurn)
                        {
                                enemyTurn = true;
                            
                        }

                        else if (enemyTurn)
                        {
                            if (!enemyMoveCheck)
                                enemy.move(enemyX - 300);

                            if (enemy.X < enemyX - 260)
                            {
                                enemyAtk = true;
                                playerDfd = true;
                                enemyMoveCheck = true;
                            }

                            if (enemyMoveCheck)
                                enemy.moveBack(enemyX);

                            if (enemyTurn && enemy.X >= enemyX)
                            {
                                enemyAtk = false;
                                playerDfd = false;
                                enemyTurn = false;
                                moveCheck = false;
                                enemyMoveCheck = false;
                                round = 1;
                            }
                        }
                    }
                    if (round == 1)
                    {
                        if (!enemyTurn)
                        {
                            if (!moveCheck)
                                player.move(playerX + 300);

                            if (player.X > playerX + 260)
                            {
                                playerAtk = true;
                                enemyDfd = true;
                                moveCheck = true;
                            }

                            if (moveCheck)
                                player.moveBack(playerX);

                            if (moveCheck && player.X <= playerX)
                            {
                                playerAtk = false;
                                enemyDfd = false;
                                enemyTurn = true;
                            }
                        }

                        else if (enemyTurn)
                        {
                            if (enemyTurn && enemy.X >= enemyX)
                            {
                                enemyAtk = false;
                                enemyTurn = false;
                                enemyMoveCheck = true;
                                round = 2;
                            }

                        }

                        if (!enemyTurn && moveCheck && enemyMoveCheck && round == 2)
                        {
                            moveCheck = false;
                            enemyMoveCheck = false;
                            round = 0;
                            ActionState = 0;
                        }
                    }
                    Invalidate();
                    break;
                case 9: // 방공방방

                    if (round == 0)
                    {
                        if (!enemyTurn)
                        {
                            if (!moveCheck)
                                player.move(playerX + 300);

                            if (player.X > playerX + 260)
                            {
                                playerAtk = true;
                                enemyDfd = true;
                                moveCheck = true;
                            }

                            if (moveCheck)
                                player.moveBack(playerX);

                            if (moveCheck && player.X <= playerX)
                            {
                                playerAtk = false;
                                enemyDfd = false;
                                enemyTurn = true;
                            }
                        }

                        else if (enemyTurn)
                        {
                            if (enemyTurn && enemy.X >= enemyX)
                            {
                                enemyAtk = false;
                                enemyTurn = false;
                                enemyMoveCheck = true;
                                round = 2;
                            }

                        }

                        if (!enemyTurn && moveCheck && enemyMoveCheck && round == 2)
                        {
                            moveCheck = false;
                            enemyMoveCheck = false;
                            round = 0;
                            ActionState = 0;
                        }
                    }
                    Invalidate();
                    break;
                case 10: // 방 공 마
                    if (!enemyTurn)
                    {
                        if (!moveCheck)
                            player.move(playerX + 300);

                        if (player.X > playerX + 260)
                        {
                            playerAtk = true;
                            moveCheck = true;
                        }

                        if (moveCheck)
                            player.moveBack(playerX);

                        if (moveCheck && player.X <= playerX)
                        {
                            playerAtk = false;
                            enemyTurn = true;
                            round = 2;
                        }
                    }

                    if (enemyTurn && moveCheck && round == 2)
                    {
                        enemyTurn = false;
                        moveCheck = false;
                        enemyMoveCheck = false;
                        round = 0;
                        ActionState = 0;
                    }

                    Invalidate();
                    break;

                case 11: // 공방 공공
                    if (round == 0)
                    {
                        if (!enemyTurn)
                        {
                            if (!moveCheck)
                                player.move(playerX + 300);

                            if (player.X > playerX + 260)
                            {
                                playerAtk = true;
                                moveCheck = true;
                            }

                            if (moveCheck)
                                player.moveBack(playerX);

                            if (moveCheck && player.X <= playerX)
                            {
                                playerAtk = false;
                                enemyTurn = true;
                            }
                        }

                        else if (enemyTurn)
                        {
                            if (!enemyMoveCheck)
                                enemy.move(enemyX - 300);

                            if (enemy.X < enemyX - 260)
                            {
                                enemyAtk = true;
                                enemyMoveCheck = true;
                            }

                            if (enemyMoveCheck)
                                enemy.moveBack(enemyX);

                            if (enemyTurn && enemy.X >= enemyX)
                            {
                                enemyAtk = false;
                                enemyTurn = false;
                                enemyMoveCheck = false;
                                round = 1;
                            }
                        }
                    }

                    if (round == 1)
                    {
                        if (!enemyTurn)
                        {
                            enemyTurn = true;
                        }

                        else if (enemyTurn)
                        {
                            if (!enemyMoveCheck)
                                enemy.move(enemyX - 300);

                            if (enemy.X < enemyX - 260)
                            {
                                enemyAtk = true;
                                playerDfd = true;
                                enemyMoveCheck = true;
                            }

                            if (enemyMoveCheck)
                                enemy.moveBack(enemyX);

                            if (enemyTurn && enemy.X >= enemyX)
                            {
                                enemyAtk = false;
                                playerDfd = false;

                                moveCheck = true;
                                enemyTurn = false;
                                round = 2;
                            }
                        }

                        if (!enemyTurn && moveCheck && enemyMoveCheck && round == 2)
                        {
                            moveCheck = false;
                            enemyMoveCheck = false;
                            round = 0;
                            ActionState = 0;
                        }
                    }
                    Invalidate();
                    break;
                case 12: // 공방방공

                    if (!enemyTurn)
                    {
                        if (!moveCheck)
                            player.move(playerX + 300);

                        if (player.X > playerX + 260)
                        {
                            playerAtk = true;
                            enemyDfd = true;
                            moveCheck = true;
                        }

                        if (moveCheck)
                            player.moveBack(playerX);

                        if (moveCheck && player.X <= playerX)
                        {
                            playerAtk = false;
                            enemyDfd = false;
                            enemyTurn = true;
                        }
                    }

                    else if (enemyTurn)
                    {
                        if (!enemyMoveCheck)
                            enemy.move(enemyX - 300);

                        if (enemy.X < enemyX - 260)
                        {
                            enemyAtk = true;
                            playerDfd = true;
                            enemyMoveCheck = true;
                        }

                        if (enemyMoveCheck)
                            enemy.moveBack(enemyX);

                        if (enemyTurn && enemy.X >= enemyX)
                        {
                            enemyAtk = false;
                            playerDfd = false;
                            enemyTurn = false;
                            round = 2;
                        }
                    }

                    if (!enemyTurn && moveCheck && enemyMoveCheck && round == 2)
                    {
                        moveCheck = false;
                        enemyMoveCheck = false;
                        round = 0;
                        ActionState = 0;
                    }

                    Invalidate();
                    break;
                case 13:
                    if (!enemyTurn)
                    {
                        if (!moveCheck)
                            player.move(playerX + 300);

                        if (player.X > playerX + 260)
                        {
                            playerAtk = true;
                            moveCheck = true;
                        }

                        if (moveCheck)
                            player.moveBack(playerX);

                        if (moveCheck && player.X <= playerX)
                        {
                            playerAtk = false;
                            enemyTurn = true;
                        }
                    }

                    else if (enemyTurn)
                    {
                        if (!enemyMoveCheck)
                            enemy.move(enemyX - 300);

                        if (enemy.X < enemyX - 260)
                        {
                            enemyAtk = true;
                            enemyMoveCheck = true;
                        }

                        if (enemyMoveCheck)
                            enemy.moveBack(enemyX);

                        if (enemyTurn && enemy.X >= enemyX)
                        {
                            enemyAtk = false;
                            enemyTurn = false;
                            round = 2;
                        }
                    }

                    if (!enemyTurn && moveCheck && enemyMoveCheck && round == 2)
                    {
                        moveCheck = false;
                        enemyMoveCheck = false;
                        round = 0;
                        ActionState = 0;
                    }

                    Invalidate();

                    break;
                case 14:
                    if (round == 0)
                    {
                        if (!enemyTurn)
                        {
                            if (!moveCheck)
                                player.move(playerX + 300);

                            if (player.X > playerX + 260)
                            {
                                playerAtk = true;
                                enemyDfd = true;
                                moveCheck = true;
                            }

                            if (moveCheck)
                                player.moveBack(playerX);

                            if (moveCheck && player.X <= playerX)
                            {
                                playerAtk = false;
                                enemyDfd = false;
                                enemyTurn = true;
                            }
                        }

                        else if (enemyTurn)
                        {
                            if (enemyTurn && enemy.X >= enemyX)
                            {
                                enemyAtk = false;
                                enemyTurn = false;
                                enemyMoveCheck = true;
                                round = 2;
                            }

                        }

                        if (!enemyTurn && moveCheck && enemyMoveCheck && round == 2)
                        {
                            moveCheck = false;
                            enemyMoveCheck = false;
                            round = 0;
                            ActionState = 0;
                        }
                    }
                    Invalidate();

                    break;
                case 15:
                    if (!enemyTurn)
                    {
                        if (!moveCheck)
                            player.move(playerX + 300);

                        if (player.X > playerX + 260)
                        {
                            playerAtk = true;
                            moveCheck = true;
                        }

                        if (moveCheck)
                            player.moveBack(playerX);

                        if (moveCheck && player.X <= playerX)
                        {
                            playerAtk = false;
                            enemyTurn = true;
                            round = 2;
                        }
                    }

                    if (enemyTurn && moveCheck && round == 2)
                    {
                        enemyTurn = false;
                        moveCheck = false;
                        enemyMoveCheck = false;
                        round = 0;
                        ActionState = 0;
                    }

                    Invalidate();
                    break;
                case 16: // 방방공공

                    if (round == 0)
                    {
                        if (!enemyTurn)
                        {
                            enemyTurn = true;
                        }

                        else if (enemyTurn)
                        {
                            if (!enemyMoveCheck)
                                enemy.move(enemyX - 300);

                            if (enemy.X < enemyX - 260)
                            {
                                enemyAtk = true;
                                playerDfd = true;
                                enemyMoveCheck = true;
                            }

                            if (enemyMoveCheck)
                                enemy.moveBack(enemyX);

                            if (enemyTurn && enemy.X >= enemyX)
                            {
                                enemyAtk = false;
                                playerDfd = false;

                                enemyTurn = false;
                                moveCheck = false;
                                enemyMoveCheck = false;
                                round = 1;
                            }
                        }
                    }

                    if (round == 1)
                    {
                        if (!enemyTurn)
                        {
                            enemyTurn = true;
                        }

                        else if (enemyTurn)
                        {
                            if (!enemyMoveCheck)
                                enemy.move(enemyX - 300);

                            if (enemy.X < enemyX - 260)
                            {
                                enemyAtk = true;
                                playerDfd = true;
                                enemyMoveCheck = true;
                            }

                            if (enemyMoveCheck)
                                enemy.moveBack(enemyX);

                            if (enemyTurn && enemy.X >= enemyX)
                            {
                                enemyAtk = false;
                                playerDfd = false;

                                moveCheck = true;
                                enemyTurn = false;
                                round = 2;
                            }
                        }

                        if (!enemyTurn && moveCheck && enemyMoveCheck && round == 2)
                        {
                            moveCheck = false;
                            enemyMoveCheck = false;
                            round = 0;
                            ActionState = 0;
                        }
                    }
                    Invalidate();


                    break;
                case 17:
                    if (round == 0)
                    {
                        if (!enemyTurn)
                        {
                            enemyTurn = true;
                        }

                        else if (enemyTurn)
                        {
                            if (!enemyMoveCheck)
                                enemy.move(enemyX - 300);

                            if (enemy.X < enemyX - 260)
                            {
                                enemyAtk = true;
                                playerDfd = true;
                                enemyMoveCheck = true;
                            }

                            if (enemyMoveCheck)
                                enemy.moveBack(enemyX);

                            if (enemyTurn && enemy.X >= enemyX)
                            {
                                enemyAtk = false;
                                playerDfd = false;

                                moveCheck = true;
                                enemyTurn = false;
                                round = 2;
                            }
                        }

                        if (!enemyTurn && moveCheck && enemyMoveCheck && round == 2)
                        {
                            moveCheck = false;
                            enemyMoveCheck = false;
                            round = 0;
                            ActionState = 0;
                        }
                    }
                    Invalidate();

                    break;
                case 18:
                    if (round == 0)
                    {
                        if (!enemyTurn)
                        {
                            enemyTurn = true;
                        }

                        else if (enemyTurn)
                        {
                            if (!enemyMoveCheck)
                                enemy.move(enemyX - 300);

                            if (enemy.X < enemyX - 260)
                            {
                                enemyAtk = true;
                                playerDfd = true;
                                enemyMoveCheck = true;
                            }

                            if (enemyMoveCheck)
                                enemy.moveBack(enemyX);

                            if (enemyTurn && enemy.X >= enemyX)
                            {
                                enemyAtk = false;
                                playerDfd = false;

                                moveCheck = true;
                                enemyTurn = false;
                                round = 2;
                            }
                        }

                        if (!enemyTurn && moveCheck && enemyMoveCheck && round == 2)
                        {
                            moveCheck = false;
                            enemyMoveCheck = false;
                            round = 0;
                            ActionState = 0;
                        }
                    }
                    Invalidate();

                    break;
                case 19:
                    ActionState = 0;

                    break;
                case 20:
                    if (time > 0)
                    {
                        enemyMag = true;
                        time--;
                    }
                    else
                    {
                        time = 10;
                        enemyMag = false;
                        ActionState = 0;
                        round = 0;
                    }
                    Invalidate();
                    break;
                case 21:
                    if (round == 0)
                    {
                        if (!enemyTurn)
                        {
                            enemyTurn = true;
                        }

                        else if (enemyTurn)
                        {
                            if (!enemyMoveCheck)
                                enemy.move(enemyX - 300);

                            if (enemy.X < enemyX - 260)
                            {
                                enemyAtk = true;
                                enemyMoveCheck = true;
                            }

                            if (enemyMoveCheck)
                                enemy.moveBack(enemyX);

                            if (enemyTurn && enemy.X >= enemyX)
                            {
                                enemyAtk = false;

                                moveCheck = true;
                                enemyTurn = false;
                                round = 2;
                            }
                        }

                        if (!enemyTurn && moveCheck && enemyMoveCheck && round == 2)
                        {
                            moveCheck = false;
                            enemyMoveCheck = false;
                            round = 0;
                            ActionState = 0;
                        }
                    }
                    Invalidate();

                    break;
                case 22:
                    if (round == 0)
                    {
                        if (!enemyTurn)
                        {
                            enemyTurn = true;
                        }

                        else if (enemyTurn)
                        {
                            if (!enemyMoveCheck)
                                enemy.move(enemyX - 300);

                            if (enemy.X < enemyX - 260)
                            {
                                enemyAtk = true;
                                enemyMoveCheck = true;
                            }

                            if (enemyMoveCheck)
                                enemy.moveBack(enemyX);

                            if (enemyTurn && enemy.X >= enemyX)
                            {
                                enemyAtk = false;

                                moveCheck = true;
                                enemyTurn = false;
                                round = 2;
                            }
                        }

                        if (!enemyTurn && moveCheck && enemyMoveCheck && round == 2)
                        {
                            moveCheck = false;
                            enemyMoveCheck = false;
                            round = 0;
                            ActionState = 0;
                        }
                    }
                    Invalidate();

                    break;
                case 23:
                    if (round == 0)
                    {
                        if (!enemyTurn)
                        {
                            enemyTurn = true;
                        }

                        else if (enemyTurn)
                        {
                            if (!enemyMoveCheck)
                                enemy.move(enemyX - 300);

                            if (enemy.X < enemyX - 260)
                            {
                                enemyAtk = true;
                                enemyMoveCheck = true;
                            }

                            if (enemyMoveCheck)
                                enemy.moveBack(enemyX);

                            if (enemyTurn && enemy.X >= enemyX)
                            {
                                enemyAtk = false;

                                moveCheck = true;
                                enemyTurn = false;
                                round = 2;
                            }
                        }

                        if (!enemyTurn && moveCheck && enemyMoveCheck && round == 2)
                        {
                            moveCheck = false;
                            enemyMoveCheck = false;
                            round = 0;
                            ActionState = 0;
                        }
                    }
                    Invalidate();

                    break;
                case 24:
                    if (time > 0)
                    {
                        playerMag = true;
                        time--;
                    }
                    else
                    {
                        time = 10;
                        playerMag = false;
                        ActionState = 0;
                        round = 0;
                    }
                    Invalidate();
                    break;
                case 25:
                    ActionState = 0;
                    break;

                case 0:
                    break;

                default:
                    break;
            }
        }

        // 게임 엔진 타이머 동작
        private void GameEngine(object sender, EventArgs e)
        {
            if (gameStart && turnCheck)
            {
                turnCheck = false;
                textBox.Items.Add(player.HP);
                textBox.Items.Add(dice.GetResult()[0] + ", " + dice.GetResult()[1] + ", " + dice.GetResult()[2]);
                textBox.Items.Add(player.Atk + ", " + player.Dfd + ", " + enemy.Atk + ", " + enemy.Dfd);

            }
            else if (!gameStart)
            {
                if (imageSize < 0)
                    loop = false;
                if (imageSize < 50 && !loop)
                    imageSize += 0.1f;
                else
                {
                    loop = true;
                    imageSize -= 0.1f;
                }
                Invalidate();
            }
        }

        private void EMouseDown(object sender, MouseEventArgs e)
        {
            if (!gameStart)
            {

                //if (e.X > panelWidth / 2 - buttonStart.Width / 4 && e.X < panelWidth / 2 + buttonStart.Width / 4 && e.Y > 280 && e.Y < 280 + buttonStart.Height / 2)
                //사각형 범위
                if(StartButton.Contains(e.X, e.Y))
                {
                    //MessageBox.Show("게임 시작");
                    mainSound.Stop();
                    gameStart = true;

                    Invalidate();
                }
                if(ExitButton.Contains(e.X, e.Y))
                {

                    //MessageBox.Show("게임 종료");
                    Application.Exit();
                }
            }
            else if (gameStart)
            {

                if (RollButton.Contains(e.X, e.Y))
                {
                    if (ActionState != 0)
                        return;

                    if (RollDice)
                    {
                        textBox.Items.Add("실행 해 주세요");

                        textBox.SelectedIndex = textBox.Items.Count - 1;
                        return;
                    }
                    else
                    {
                        TurnEnd = false;
                        RollDice = true;
                        TurnRoll = true;
                        Invalidate();
                    }
                }
                if (RunButton.Contains(e.X, e.Y))
                {
                    if (ActionState != 0)
                        return;

                    if (TurnEnd)
                    {
                        textBox.Items.Add("주사위를 굴려주세요");

                        textBox.SelectedIndex = textBox.Items.Count - 1;
                        return;
                    }
                    RunGame();
                }

            }
        }

        private void GUIView(PaintEventArgs e)
        {
            e.Graphics.DrawImage(Roll, RollButton);
            //TurnSetDice(e.Graphics);
            e.Graphics.DrawImage(Run, RunButton);
        }

        private void TurnSetDice(Graphics g)
        {
            dice.DrawDiceME(g, 225, player.Y);
            dice.DrawDiceEN(g, 675, enemy.Y);
            dice.DrawDamage(g, 450, 200);
            SetAllStat();
            turnCheck = true;
        }

        private void SetAllStat()
        {
            player.SetStat(dice.GetResult()[0], dice.GetResult()[2]);
            enemy.SetStat(dice.GetResult()[1], dice.GetResult()[2]);
        }

        private void RunGame()
        {

            if (!Mag.Checked)
            {
                if (!OneAtk.Checked && !OneDfd.Checked || !TwoAtk.Checked && !TwoDfd.Checked)
                {
                    textBox.Items.Add("정하지 않은 행동이 있습니다. 행동을 정해주세요");

                    textBox.SelectedIndex = textBox.Items.Count - 1;
                    return;
                }
            }

            bool check1 = false;
            bool check2 = false;
            bool check3 = false;

            textBox.Items.Add("행동");
            curtain = 1; ;
            if (!Mag.Checked)
            {
                check3 = false;

                if (curtain == 1)
                {
                    if (OneAtk.Checked)
                        check1 = true;

                    curtain = 2;
                    
                    if (curtain == 2)
                    {
                        if (TwoAtk.Checked)
                            check2 = true;

                        curtain = 0;
                    }
                }
            }
            else
            {
                check3 = true;
                textBox.Items.Add("마법");
            }

            if (check3)
                state = 4;
            else if (check1 && check2)
                state = 0;
            else if (!check1 && check2)
                state = 1;
            else if (check1 && !check2)
                state = 2;
            else if (!check1 && !check2)
                state = 3;


            RollDice = false;

            AIState();
            Fight();

            TurnEnd = true;
        }

        private void AIState()
        {
            textBox.Items.Add(player.Atk + ", " + player.Dfd + ", " + enemy.Atk + ", " + enemy.Dfd);

            if (player.Atk < enemy.Atk)
            {
                int temp = patten.Next(100);
                if (50 < temp)
                    stateAI = 0;
                else if (40 < temp && 50 >= temp)
                    stateAI = 1;
                else if (30 < temp && 40 >= temp)
                    stateAI = 2;
                else
                    stateAI = 4;
            }
            else if (player.Atk >= enemy.Atk)
            {
                int temp = patten.Next(100);
                if (50 < temp)
                    stateAI = 3;
                else if (30 < temp && 50 >= temp)
                    stateAI = 1;
                else if (10 < temp && 30 >= temp)
                    stateAI = 2;
                else
                    stateAI = 4;
            }
        }

        private void Fight()
        {
            switch(state){
                case 0: // 공공
                    if (stateAI == 0)  // 적 공공
                    {
                        textBox.Items.Add("공격 주고 받음");
                        player.SetHP(enemy.Atk);

                        enemy.SetHP(player.Atk);
                        ActionState = 1;
                    }
                    else if (stateAI == 1)  // 적 방공
                    {
                        textBox.Items.Add("플레이어 공격, 적 방어 / 플레이어 공격, 적 공격");

                        if (player.Atk > enemy.Dfd)
                            enemy.SetHP(player.Atk - enemy.Dfd);

                        player.SetHP(enemy.Atk / 2);
                        enemy.SetHP(player.Atk / 2);

                        ActionState = 2;
                    }
                    else if (stateAI == 2)  // 적 공방
                    {
                        textBox.Items.Add("플레이어 공격, 적 공격 / 플레이어 공격, 적 방어");

                        player.SetHP(enemy.Atk / 2);
                        enemy.SetHP(player.Atk / 2);

                        if (player.Atk > enemy.Dfd)
                            enemy.SetHP(player.Atk - enemy.Dfd);
                        
                        ActionState = 3;
                    }
                    else if (stateAI == 3)  // 적 방방
                    {
                        textBox.Items.Add("플레이어 공격, 적 방어 / 플레이어 공격, 적 방어");

                        if (player.Atk > enemy.Dfd)
                            enemy.SetHP(player.Atk - enemy.Dfd);
                        if (player.Atk > enemy.Dfd)
                            enemy.SetHP(player.Atk - enemy.Dfd);

                        ActionState = 4;
                    }
                    else if (stateAI == 4)  // 적 마법
                    {
                        textBox.Items.Add("플레이어 공격, 적 마법 캔슬 / 플레이어 공격, 적 경직");

                        enemy.SetHP(player.Atk);

                        ActionState = 5;
                    }
                    break;

                case 1: // 방공
                    if (stateAI == 0)  // 적 공공
                    {
                        textBox.Items.Add("플레이어 방어, 적 공격 / 플레이어 공격, 적 공격");

                        if (enemy.Atk > player.Dfd)
                            player.SetHP(enemy.Atk - player.Dfd);

                        player.SetHP(enemy.Atk / 2);
                        enemy.SetHP(player.Atk / 2);

                        ActionState = 6;
                    }
                    else if (stateAI == 1)  // 적 방공
                    {
                        textBox.Items.Add("플레이어 방어, 적 방어 / 플레이어 공격, 적 공격");

                        if (player.Dfd > enemy.Dfd)
                            player.SetHeal(player.Dfd - enemy.Dfd);
                        else if (player.Dfd < enemy.Dfd)
                            enemy.SetHeal(enemy.Dfd - player.Dfd);

                        player.SetHP(enemy.Atk / 2);
                        enemy.SetHP(player.Atk / 2);

                        ActionState = 7;
                    }
                    else if (stateAI == 2)  // 적 공방
                    {
                        textBox.Items.Add("플레이어 방어, 적 공격 / 플레이어 공격, 적 방어");

                        if (enemy.Atk > player.Dfd)
                            player.SetHP(enemy.Atk - player.Dfd);

                        if (player.Atk > enemy.Dfd)
                            enemy.SetHP(player.Atk - enemy.Dfd);

                        ActionState = 8;
                    }
                    else if (stateAI == 3)  // 적 방방
                    {
                        textBox.Items.Add("플레이어 방어, 적 방어 / 플레이어 공격, 적 방어");

                        if (player.Dfd > enemy.Dfd)
                            player.SetHeal(player.Dfd - enemy.Dfd);
                        else if (player.Dfd < enemy.Dfd)
                            enemy.SetHeal(enemy.Dfd - player.Dfd);

                        if (player.Atk > enemy.Dfd)
                            enemy.SetHP(player.Atk - enemy.Dfd);

                        ActionState = 9;
                    }
                    else if (stateAI == 4)  // 적 마법
                    {
                        textBox.Items.Add("플레이어 방어, 적 마법 캐스팅 / 플레이어 공격, 적 마법 캔슬");

                        enemy.SetHP(player.Atk);

                        ActionState = 10;
                    }
                    break;

                case 2: // 공방
                    if (stateAI == 0) // 적 공공
                    {
                        textBox.Items.Add("플레이어 공격, 적 공격 / 플레이어 방어, 적 공격");

                        player.SetHP(enemy.Atk / 2);
                        enemy.SetHP(player.Atk / 2);


                        if (enemy.Atk > player.Dfd)
                            player.SetHP(enemy.Atk - player.Dfd);

                        ActionState = 11;
                    }
                    else if (stateAI == 1)  // 적 방공
                    {
                        textBox.Items.Add("플레이어 공격, 적 방어 / 플레이어 방어, 적 공격");

                        if (player.Atk > enemy.Dfd)
                            enemy.SetHP(player.Atk - enemy.Dfd);

                        if (enemy.Atk > player.Dfd)
                            player.SetHP(enemy.Atk - player.Dfd);

                        ActionState = 12;
                    }
                    else if (stateAI == 2)  // 적 공방
                    {
                        textBox.Items.Add("플레이어 공격, 적 공격 / 플레이어 방어, 적 방어");

                        player.SetHP(enemy.Atk / 2);
                        enemy.SetHP(player.Atk / 2);

                        if (player.Dfd > enemy.Dfd)
                            player.SetHeal(player.Dfd - enemy.Dfd);
                        else if (player.Dfd < enemy.Dfd)
                            enemy.SetHeal(enemy.Dfd - player.Dfd);

                        ActionState = 13;
                    }
                    else if (stateAI == 3)  // 적 방방
                    {
                        textBox.Items.Add("플레이어 공격, 적 방어 / 플레이어 방어, 적 방어");

                        if (player.Atk > enemy.Dfd)
                            enemy.SetHP(player.Atk - enemy.Dfd);

                        if (player.Dfd > enemy.Dfd)
                            player.SetHeal(player.Dfd - enemy.Dfd);
                        else if (player.Dfd < enemy.Dfd)
                            enemy.SetHeal(enemy.Dfd - player.Dfd);

                        ActionState = 14;
                    }
                    else if (stateAI == 4)  // 적 마법
                    {
                        textBox.Items.Add("플레이어 공격, 적 마법 캔슬");

                        enemy.SetHP(player.Atk);

                        ActionState = 15;
                    }
                    break;

                case 3: // 방방
                    if (stateAI == 0)  // 적 공공
                    {
                        textBox.Items.Add("플레이어 방어, 적 공격 / 플레이어 방어, 적 공격");

                        if (enemy.Atk > player.Dfd)
                            player.SetHP(enemy.Atk - player.Dfd);

                        if (enemy.Atk > player.Dfd)
                            player.SetHP(enemy.Atk - player.Dfd);

                        ActionState = 16;
                    }
                    else if (stateAI == 1)  // 적 방공
                    {
                        textBox.Items.Add("플레이어 방어, 적 방어 / 플레이어 방어, 적 공격");

                        if (player.Dfd > enemy.Dfd)
                            player.SetHeal(player.Dfd - enemy.Dfd);
                        else if (player.Dfd < enemy.Dfd)
                            enemy.SetHeal(enemy.Dfd - player.Dfd);

                        if (enemy.Atk > player.Dfd)
                            player.SetHP(enemy.Atk - player.Dfd);

                        ActionState = 17;
                    }
                    else if (stateAI == 2)  // 적 공방
                    {
                        textBox.Items.Add("플레이어 방어, 적 공격 / 플레이어 방어, 적 방어");

                        if (enemy.Atk > player.Dfd)
                            player.SetHP(enemy.Atk - player.Dfd);

                        if (player.Dfd > enemy.Dfd)
                            player.SetHeal(player.Dfd - enemy.Dfd);
                        else if (player.Dfd < enemy.Dfd)
                            enemy.SetHeal(enemy.Dfd - player.Dfd);

                        ActionState = 18;
                    }
                    else if (stateAI == 3)  // 적 방방
                    {
                        textBox.Items.Add("플레이어 방어, 적 방어 / 플레이어 방어, 적 방어");

                        if (player.Dfd > enemy.Dfd)
                            player.SetHeal(player.Dfd - enemy.Dfd);
                        else if (player.Dfd < enemy.Dfd)
                            enemy.SetHeal(enemy.Dfd - player.Dfd);

                        if (player.Dfd > enemy.Dfd)
                            player.SetHeal(player.Dfd - enemy.Dfd);
                        else if (player.Dfd < enemy.Dfd)
                            enemy.SetHeal(enemy.Dfd - player.Dfd);

                        ActionState = 19;
                    }
                    else if (stateAI == 4)  // 적 마법
                    {
                        textBox.Items.Add("적 마법 적중");

                        player.SetHP(enemy.Atk * 2);

                        ActionState = 20;
                    }
                    break;
                case 4: // 마법
                    if (stateAI == 0)  // 적 공공
                    {
                        textBox.Items.Add("플레이어 마법 캔슬");

                        player.SetHP(enemy.Atk);

                        ActionState = 21;
                    }
                    else if (stateAI == 1) // 적 방공
                    {
                        textBox.Items.Add("플레이어 마법 캐스팅, 적 방어 / 플레이어 마법 캔슬");

                        player.SetHP(enemy.Atk);

                        ActionState = 22;
                    }
                    else if (stateAI == 2)  // 적 공방
                    {
                        textBox.Items.Add("플레이어 마법 캔슬, 적 공격");

                        player.SetHP(enemy.Atk);

                        ActionState = 23;
                    }
                    else if (stateAI == 3)  // 적 방방
                    {
                        textBox.Items.Add("플레이어 마법 적중");

                        enemy.SetHP(player.Atk * 2);

                        ActionState = 24;
                    }
                    else if (stateAI == 4)  // 적 마법
                    {
                        textBox.Items.Add("서로 마법 캔슬");

                        ActionState = 25;
                    }
                    break;

                default:
                    break;
            }

            if (player.HP < 0)
                player.ReSet(0);
            if (enemy.HP < 0)
                enemy.ReSet(0);

            textBox.SelectedIndex = textBox.Items.Count - 1;

            Invalidate();

            TurnEnding();

        }

        private void TurnEnding()
        {
            OneAtk.Checked = false;
            OneDfd.Checked = false;
            TwoAtk.Checked = false;
            TwoDfd.Checked = false;
            Mag.Checked = false;


            if (player.HP <= 0)
            {
                MessageBox.Show("게임 종료 \n플레이어 패배");
                GameReSet();
            }
            else if (enemy.HP <= 0)
            {
                MessageBox.Show("게임 종료 \n플레이어 승리");

                GameReSet();
            }

            Invalidate();
        }
        
        private void GameReSet()
        {
            gameStart = false;
            textBox.Items.Clear();
            panel1.Visible = false;
            player.ReSet(300);
            enemy.ReSet(300);
        }

        private void Mag_CheckedChanged(object sender, EventArgs e)
        {
            if (Mag.Checked)
            {
                OneAtk.Checked = false;
                OneDfd.Checked = false;
                TwoAtk.Checked = false;
                TwoDfd.Checked = false;
            }
        }

        private void OneAtk_CheckedChanged(object sender, EventArgs e)
        {
            if(Mag.Checked && OneAtk.Checked)
                Mag.Checked = false;
        }

        private void OneDfd_CheckedChanged(object sender, EventArgs e)
        {
            if (Mag.Checked && OneDfd.Checked)
                Mag.Checked = false;
        }

        private void TwoAtk_CheckedChanged(object sender, EventArgs e)
        {
            if (Mag.Checked && TwoAtk.Checked)
                Mag.Checked = false;
        }

        private void TwoDfd_CheckedChanged(object sender, EventArgs e)
        {
            if (Mag.Checked && TwoDfd.Checked)
                Mag.Checked = false;
        }
    }
}
