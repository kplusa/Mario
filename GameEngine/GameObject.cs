using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;
using SFML.Graphics;
using SFML.Audio;

namespace GameEngine
{
    public class GameObject : IDisposable
    {
        private RenderWindow window;
        public RenderWindow Window { get { return this.window; } }
        public SceneManager SceneManager = new SceneManager();

        /**\brief Konstruktor obiektu GameObject korzystający z klasy IDisposable 
         * @param Title nazwa okna
          */
        public GameObject(string Title)
        {
            window = new RenderWindow(new VideoMode(1024u, 768u), Title, Styles.Default);
            window.SetVisible(true);
            window.SetVerticalSyncEnabled(true);
            window.SetFramerateLimit(30);
            window.Closed += windowClosed;
            window.KeyPressed += windowKeyPressed;
            window.KeyReleased += windowKeyReleased;
        }
        /// <summary>
        /// Metoda obsługi klawiatury
        /// </summary>
        /// <param name="sender">obiekt klawiatury</param>
        /// <param name="e">przycisk</param>
        void windowKeyPressed(object sender, SFML.Window.KeyEventArgs e)
        {
            SceneManager.CurrentScene.HandleKeyPress(e);
        }
        /// <summary>
        /// Metoda obsługi klawiatury
        /// </summary>
        /// <param name="sender">obiekt klawiatury</param>
        /// <param name="e">przycisk</param>
        void windowKeyReleased(object sender, SFML.Window.KeyEventArgs e)
        {
            SceneManager.CurrentScene.HandleKeyReleased(e);
        }
        /// <summary>
        /// Metoda zamykania okna
        /// </summary>
        /// <param name="sender">obiekt klawiatury</param>
        /// <param name="e">przycisk</param>
        void windowClosed(object sender, EventArgs e)
        {
            window.Close();
        }
        /// <summary>
        /// Metoda zamykania okna
        /// </summary>

        public void Close()
        {
            this.window.Close();
        }
        /// <summary>
        /// Metoda pobierania szerokosci okna
        /// </summary>
        public float GetWindowX()
        {
            return window.Size.X;
        }
        /// <summary>
        /// Metoda pobierania wysokości okna
        /// </summary>
        public float GetWindowY()
        {
            return window.Size.Y;
        }
        /// <summary>
        /// Metoda ograniczająca zużycie pamięci
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Metoda ograniczająca zużycie pamięci
        /// </summary>
        /// <param name="disposing">bool</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                window.Dispose();
            }
        }
    }
}
