using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace GameEngine
{
    public class SceneManager
    {
        Dictionary<string, Scene> scenes = new Dictionary<string, Scene>();

        public Scene CurrentScene = null;
        /**\brief Konstruktor klasy SceneManager
         */
        public SceneManager()
        {

        }
        /// <summary>
        /// Metoda dodająca scenę
        /// </summary>
        /// <param name="s">scena</param>
        public void AddScene(Scene s)
        {
            scenes.Add(s.Name, s);

            s.Initialize();
        }
        /// <summary>
        /// Metoda wywołująca scenę
        /// </summary>
        /// <param name="name">nazwa sceny</param>
        public void StartScene(string name)
        {
            CurrentScene = scenes[name];
            CurrentScene.Reset();
            CurrentScene.Run();
        }
        /// <summary>
        /// Metoda pozwalająca na pobranie sceny
        /// </summary>
        /// <param name="name">nazwa sceny</param>
        /// <returns>tablica nazw scen</returns>
        public Scene GetScene(string name)
        {
            return scenes[name];
        }

    }
}
