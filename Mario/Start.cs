﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine;
using SFML.Graphics;
using SFML.Audio;
using SFML.Window;
using SFML.System;

namespace Mario
{
    public class StartScene : Scene
    {
        Text text;
        /// <summary>
        /// Konstruktor sceny początkowej
        /// </summary>
        /// <param name="gameObject">obiekt sceny</param>
        public StartScene(GameObject gameObject) : base(gameObject)
        {
            Color color = new Color(181, 232, 255);
            this.BackgroundColor = color;
        }
        /// <summary>
        /// Inicjacia sceny początkowej
        /// </summary>
        public override void Initialize()
        {
            Font arial = new Font(@"resources\arial.ttf");

            text = new Text("", arial);
            text.Position = new Vector2f(0, 0);
            text.CharacterSize = 30;

        }
        /// <summary>
        /// Resetowanie sceny
        /// </summary>
        public override void Reset()
        {
            Characters.Mario mario = new Characters.Mario(this.gameObject);
            mario.X = 430;
            mario.Y = 360;
            mario.sprite.TextureRect = mario.EntitySpriteSheet.GetFirstSprite(Direction.RIGHT);
            this.Entities.Add(mario);

            base.Reset();
        }
        /// <summary>
        /// Metoda obsługi klawiatury
        /// </summary>
        /// <param name="e">Event klawisza</param>
        public override void HandleKeyPress(KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Space)
            {
                gameObject.SceneManager.StartScene("play");
            }

            if (e.Code == Keyboard.Key.Escape)
                this.gameObject.Window.Close();

            base.HandleKeyPress(e);
        }
        /// <summary>
        /// Metoda umieszczająca napisy na scenie
        /// </summary>
        public override void Update()
        {
            string t = "MARIO";
            text.DisplayedString = t;
            text.Position = new Vector2f(100, 50);
            text.Draw(this.gameObject.Window, RenderStates.Default);

            t = ((MainScene)gameObject.SceneManager.GetScene("play")).Score.ToString("000000");
            text.DisplayedString = t;
            text.Position = new Vector2f(100, 80);
            text.Draw(this.gameObject.Window, RenderStates.Default);

            t = "x " + ((MainScene)gameObject.SceneManager.GetScene("play")).Lives.ToString("00");
            text.DisplayedString = t;
            text.Position = new Vector2f(300, 80);
            text.Draw(this.gameObject.Window, RenderStates.Default);

            t = "WORLD";
            text.DisplayedString = t;
            text.Position = new Vector2f(530, 50);
            text.Draw(this.gameObject.Window, RenderStates.Default);

            t = "1-1";
            text.DisplayedString = t;
            text.Position = new Vector2f(560, 80);
            text.Draw(this.gameObject.Window, RenderStates.Default);

            t = "TIME";
            text.DisplayedString = t;
            text.Position = new Vector2f(830, 50);
            text.Draw(this.gameObject.Window, RenderStates.Default);

            t = "WORLD 1-1";
            text.DisplayedString = t;
            text.Position = new Vector2f(420, 300);
            text.Draw(this.gameObject.Window, RenderStates.Default);

            t = "x " + ((MainScene)gameObject.SceneManager.GetScene("play")).Lives.ToString("00");
            text.DisplayedString = t;
            text.Position = new Vector2f(500, 380);
            text.Draw(this.gameObject.Window, RenderStates.Default);

            t = "[SPACE] To Begin";
            text.DisplayedString = t;
            text.Position = new Vector2f(380, 580);
            text.Draw(this.gameObject.Window, RenderStates.Default);



        }
        /// <summary>
        /// Metoda rysująca obiekty na scenie
        /// </summary>
        public override void Draw()
        {
            foreach (Entity e in Entities)
                e.Draw();
        }
        /// <summary>
        /// Metoda rysująca tło
        /// </summary>
        public override void DrawBackground()
        {
        }

    }
}
