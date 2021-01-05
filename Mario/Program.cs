using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameEngine;

namespace Mario
{
    static class Program
    {
        //..
        [STAThread]
        static void Main()
        {

            var game = new GameObject("Mario");

            ResourceManager.GetInstance().LoadSpriteSheetFromFile("mario", @"resources\mario.png", 10);
            StartScene start = new StartScene(game);
            start.Name = "start";
            game.SceneManager.AddScene(start);
            MainScene s = new MainScene(game);
            s.Name = "play"; 
            game.SceneManager.AddScene(s);
            

            GameOver gameOver = new GameOver(game);
            gameOver.Name = "gameover";
            game.SceneManager.AddScene(gameOver);
            

            WinScene win = new WinScene(game);
            win.Name = "win";
            game.SceneManager.AddScene(win);
            game.SceneManager.StartScene("start");

        }
    }
}
