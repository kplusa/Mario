using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Diagnostics;

namespace GameEngine
{
    public class Scene : IDisposable 
    {
        public string Name;
        public List<Entity> Entities = new List<Entity>();
        public Viewport viewPort;
        public Texture BackgroundTexture;
        public long LastCycleTime = 0;
        DateTime currentTime = System.DateTime.Now;
        DateTime targetTime = System.DateTime.Now;
        private bool pause = false;
        protected GameObject gameObject;
        protected Sprite BackSprite;
        public Color BackgroundColor = Color.Black;
        public Level level = new Level();
        /**\brief Konstruktor klasy Scene 
         * @param gameObject główna scena
          */
        public Scene(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }
        /// <summary>
        /// Metoda inicjalizacji
        /// </summary>
        public virtual void Initialize()
        {
            if (this.BackgroundTexture == null)
                BackSprite = new Sprite();
            else
                BackSprite = new Sprite(this.BackgroundTexture);
        }
        /// <summary>
        /// Metoda reset
        /// </summary>
        public virtual void Reset()
        {

        }
        /// <summary>
        /// Metoda uruchamiająca sceny
        /// </summary>
        public void Run()
        {
       
            while (gameObject.Window.IsOpen)
            {
                currentTime = System.DateTime.Now;

                gameObject.Window.Clear(this.BackgroundColor);

                this.DrawBackground();

                if (!pause)
                {
                    this.Update();
                    this.Move();
                    this.Draw();
                    gameObject.Window.Display();
                }

                gameObject.Window.DispatchEvents();
            }
        }
        /// <summary>
        /// Metoda obslugujaca klawiature
        /// </summary>
        /// <param name="e">Event z klawiatury</param>
        public virtual void HandleKeyPress(KeyEventArgs e)
        {

        }
        /// <summary>
        /// Metoda obslugujaca klawiature
        /// </summary>
        /// <param name="e">Event z klawiatury</param>
        public virtual void HandleKeyReleased(KeyEventArgs e)
        {

        }
        /// <summary>
        /// Metoda rysująca tło
        /// </summary>
        public virtual void DrawBackground()
        {
            BackSprite.Position = new Vector2f(0, 0);

            BackSprite.Draw(gameObject.Window, RenderStates.Default);
        }
        /// <summary>
        /// Metoda aktualizująca
        /// </summary>
        public virtual void Update()
        {

        }
        /// <summary>
        /// Metoda od poruszania się
        /// </summary>
        public virtual void Move()
        {
           
        }
        /// <summary>
        /// Metoda pozwalająca na rysowanie obiektów
        /// </summary>
        public virtual void Draw()
        {
         
        }
        /// <summary>
        /// Metoda oczyszczająca pamięć
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Metoda oczyszczająca pamięć
        /// </summary>
        /// <param name="disposing">pamięć</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                BackSprite.Dispose();
            }
        }
        
        

        
    }
}
