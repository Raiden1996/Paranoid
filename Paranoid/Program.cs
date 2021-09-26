using GraphDLL;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paranoid
{
    class Program
    {
        static int score = 0;
        static int life = 3;
        static int level = 0;

        static void PlayAgain()
        {
            for (; ; )
            {
                int x, y, click;
                Graph.getmouse(out x, out y, out click);
                Graph.image("z.png", x - 20, y - 20, x + 20, y + 20);
                Graph.delay(0);
                Graph.image("zw2.png", 0, 0, 800, 600);
                if (x > 233 && y > 310 & x < 333 && y < 415 && click == 1)
                {
                    Graph.playsound("1.mp3");
                    newgame();
                }  //yes
                if (x > 444 && y > 303 & x < 597 && y < 409 && click == 1)
                {
                    Graph.nosound();
                    mainmenu();
                }  //no

            }
        }
      
        static void newgame()
             {
                 Graph.playsound("1.mp3");
                 Graph.playsound("Count.mp3");
                 int m=5;
                 for (int i = 1; i <=5; i++)
                 {
                     Graph.image("1s" + m + ".png", 0, 0, 800, 600);
                     m = m - 1;
                     Graph.delay(1200);
                 }
                 Graph.image("Go.jpg", 0, 0, 800, 600);
                 Graph.delay(1000);
                 Graph.setfont("Regular", FontStyle.Bold,35);
                 
                 double speed=2;
                 double speed1=3;
                 double x=400,y=300;
                 double x1 = 400;//racket
                 double dx = speed, dy = -speed;
                
            Random dice2 = new Random();
                 double x2 = dice2.Next(180,700), y2 = -50;//bomb
                
            Random dice3 = new Random();     
            double x3 = dice3.Next(130, 500), y3 = -50;
           
            Random dice4 = new Random();     
            double x4 = dice4.Next(80, 300), y4 = -50;
            
            Random dice5 = new Random();      
            double x5 = dice5.Next(30, 200), y5 = -50;
                 for (; ; )
                 {
                     Graph.image("background.jpg", 0, 0, 800, 600);
                     Graph.image("ball.png",(int)x-69,(int)y-69,(int)x+69,(int) y+69);
                     Graph.image("b.png",(int) x1 - 69 ,500,(int) x1 + 69,600);
                     Graph.image("bomb.png", (int)x2 - 50, (int)y2 - 50, (int)x2 + 50, (int)y2 + 50);
                     Graph.image("coin.png", (int)x3 - 25, (int)y3 - 25, (int)x3 + 25, (int)y3 + 25);
                     Graph.image("bomb2.png", (int)x4 - 50, (int)y4 - 50, (int)x4 + 50, (int)y4 + 50);
                     Graph.image("Health.png", (int)x5 - 25, (int)y5 - 25, (int)x5 + 25, (int)y5 + 25);
                     Graph.setcolor(Color.Black);
                     Graph.outtextxy(0, 0, "Score = " + score);
                     Graph.setcolor(Color.Green);
                     Graph.outtextxy(0, 30, "Life = " + life);
                     Graph.setcolor(Color.Red);
                     Graph.outtextxy(0, 60, "Level = " + level);
                     Graph.delay(0);
                     x = x + dx;
                     y = y + dy;
                     y2 = y2 +speed1 ;
                     y3 = y3 + 2;
                     y4 = y4 + 1;
                     y5 = y5 + 3;
                     if (y5 == 520 && x5 >= x1 - 60 && x5 <= x1 + 60)
                     {
                         Graph.playwave("Yes.wav");
                         Graph.delay(700);
                         life++;
                     }
                     if (y4 == 520 && x4 >= x1 - 60 && x4 <= x1 + 60)
                     {
                         Graph.playwave("fall 2.wav");
                         Graph.image("fire.png", (int)x1 - 69, 500, (int)x1 + 69, 600);
                         Graph.delay(700);
                         life--;
                         if (life == 0) GameOver();
                     }
                     if (y2==520 && x2>=x1-60 && x2<=x1+60)
                     {
                         Graph.playwave("fall 2.wav");
                         Graph.image("fire.png", (int)x1 - 69, 500, (int)x1 + 69, 600);
                         Graph.delay(700);
                     life--;
                     if (life == 0) GameOver();
                     }
                 if (y3 == 520 && x3 >= x1 - 60 && x3 <= x1 + 60)
                 {
                   Graph.playwave("coin.wav");
                     Graph.delay(700);
                     score++;
                     if (life == 0) GameOver();
                 }
               
                     if (y2 > 650)
                 {
                     x2 = dice2.Next(180, 700);
                     y2 = -50;
                 }
                     else
                         if (y3 > 650)
                         {
                             x3 = dice3.Next(130, 500);
                             y3 = -50;
                         }
                     else
                         if(y4>650)
                         {
                             x4 = dice4.Next(80, 300);
                         y4 = -50;
                     }
                     else
                         if (y5 > 650)
                         {
                             x5 = dice5.Next(30, 200);
                             y5 = -50;
                         }
                 
                     else
                     
                     if (y < 69) dy = -dy;
                     if (x > 700) dx = -dx;
                     if (x < 100) dx = -dx;
                     if (y > 500) dy = -dy;
                     if (Graph.keydown(Keys.Left)&& x1>80) x1 = x1 - 4;
                     if (Graph.keydown(Keys.Right)&& x1<720) x1 = x1 + 4;
                     if (y > 482)
                     {
                       if (x > x1 - 100 && x < x1 + 100)
                         {
                             dy = -dy;
                             Graph.playsound("Impact.mp3");
                             score++;
                             if (score % 3 == 0)
                             {
                                 level++;
                                 if (dx > 0) dx++; else dx--;
                                 if (dy > 0) dy++; else dy--;
                                 dx = (x - x1) / 100 * speed;
                             }
                         }
                         else
                         {
                             if (life == 0) GameOver();
                             else
                             {
                                 Graph.playsound("exp.mp3");
                                 life--;
                                 dy = -dy;
                                 if (life == 0) GameOver();
                                 
                                 }
                             }
                         }
                     }
                 }

        static void GameOver()
        {
            Graph.image("Final.png", 0, 0, 800, 600);
            Graph.delay(50);
            Graph.copybackground();
            Graph.setcolor(Color.Brown);
            Graph.setfont("Regular", FontStyle.Regular, 70);
            Graph.pastebackground();
            Graph.outtextxy(150, 200, "Your Final Score = " + score);
            Graph.delay(5000);
            PlayAgain();
        }     

        static void credits()
             {

                 Graph.playsound("1.mp3");
                 int n = 1;
                 for (int i = 1; i <= 5; i++)
                 {
                     Graph.image("4d" + n + ".png", 0, 0, 800, 600);
                     n = n + 1;
                     Graph.delay(350);
                 }


                 for (; ; )
                 {
                     int x, y, click;
                     Graph.getmouse(out x, out y, out click);
                     Graph.image("z.png", x - 20, y - 20, x + 20, y + 20);
                     Graph.delay(0);
                     Graph.image("4d4.png", 0, 0, 800, 600);

                     if (x > 88 && y > 484 & x < 213 && y < 542 && click == 1)
                     {
                         Graph.playsound("2.mp3");
                         mainmenu();
                     }
                 }

             }
             static void help()
             {
                 Graph.playsound("1.mp3");
                 int n = 1;
                 for (int i = 1; i <= 5; i++)
                 {
                     Graph.image("6d" + n + ".png", 0, 0, 800, 600);
                     n = n + 1;
                     Graph.delay(350);
                 }


                 for (; ; )
                 {
                     int x, y, click;
                     Graph.getmouse(out x, out y, out click);
                     Graph.image("z.png", x - 20, y - 20, x + 20, y + 20);
                     Graph.delay(0);
                     Graph.image("6d5.png", 0, 0, 800, 600);

                     if (x > 88 && y > 484 & x < 213 && y < 542 && click == 1)
                     {
                         Graph.playsound("2.mp3");
                         mainmenu();
                     }
                 }

             }
             static void about()
             {


                 Graph.playsound("1.mp3");
                 int n = 1;
                 for (int i = 1; i <= 5; i++)
                 {
                     Graph.image("7d" + n + ".png", 0, 0, 800, 600);
                     n = n + 1;
                     Graph.delay(350);
                 }


                 for (; ; )
                 {
                     int x, y, click;
                     Graph.getmouse(out x, out y, out click);
                     Graph.image("z.png", x - 20, y - 20, x + 20, y + 20);
                     Graph.delay(0);
                     Graph.image("7d5.png", 0, 0, 800, 600);

                     if (x > 88 && y > 484 & x < 213 && y < 542 && click == 1)
                     {
                         Graph.playsound("2.mp3");
                         mainmenu();
                     }
                 }

             }
            
             static void exit()
             {
                 for (; ; )
                 {
                     int x, y, click;
                     Graph.getmouse(out x, out y, out click);
                     Graph.image("z.png", x - 20, y - 20, x + 20, y + 20);
                     Graph.delay(0);
                     Graph.playsound("1.mp3");
                     Graph.image("5d1.png", 0, 0, 800, 600);
                     if (x > 443 && y > 318 & x < 613 && y < 426&& click==1)
                         //nope
                     {
                         Graph.playsound("1.mp3"); 
                         mainmenu();
                     }
                         
  if (x > 216 && y > 318 & x < 378 && y < 426 && click == 1)  //yep
                     {
                         Graph.playsound("2.mp3");
                         break;
                     }

                 }

                 Graph.closegraph();
             }


             static void mainmenu()
             {
                 string pic = "1d1.png";

                 Graph.hidemouse();
                 for (; ; )
                 {
                     Graph.setcolor(Color.Black);
                     Graph.image(pic, 0, 0, 800, 600);
                     int x, y, click;
                     Graph.getmouse(out x, out y, out click);
                     Graph.image("z.png", x - 20, y - 20, x + 20, y + 20);
                     Graph.delay(0);
                     if (x > 582 && y > 135 && x < 772 && y < 209)//New Game
                         if (click == 1) newgame(); else pic = "3d1.png";
                     else
                         if (x > 582 && y > 220 && x < 772 && y < 294) //Credits
                             if (click == 1) credits(); else pic = "3d2.png";
                         else
                             if (x > 582 && y > 304 && x < 772 && y < 379) //Help
                                 if (click == 1) help(); else pic = "3d3.png";
                             else
                                 if (x > 582 && y > 393 && x < 772 && y < 467) //About
                                     if (click == 1) about(); else pic = "3d4.png";
                                 else
                                     if (x > 582 && y > 479 && x < 772 && y < 555) //Exit
                                         if (click == 1) exit(); else pic = "3d5.png";
                                     else pic = "1d1.png";

                 }
             }
        
        static void Main(string[] args)
        {
            Graph.skiplogo();
            Graph.initgraph(800, 600);
            mainmenu ();
        }
    }
}
