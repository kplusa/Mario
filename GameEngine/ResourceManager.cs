using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Audio;

namespace GameEngine
{
    public class ResourceManager
    {
        private static ResourceManager instance = null;
        Dictionary<string, Texture> textures = new Dictionary<string, Texture>();
        Dictionary<string, SpriteSheet> spriteSheets = new Dictionary<string, SpriteSheet>();
        Dictionary<string, Sound> sound = new Dictionary<string, Sound>();
        /// <summary>
        /// Metoda pozwalajaca na pobranie  instancji
        /// </summary>
        /// <returns>Instancja</returns>
        public static ResourceManager GetInstance()
        {
            if (instance == null)
            {
                instance = new ResourceManager();
            }
            return instance;
        }
        /// <summary>
        /// Metoda łądująca teksturę dla obiektu
        /// </summary>
        /// <param name="name">nazwa tekstury</param>
        /// <param name="path">ścieżka do tekstury</param>
        public void LoadTexture(string name, string path)
        {
            if(GetTexture(name) == null)
            { 
                Texture texture = new Texture(path);
                textures.Add(name, texture);
            }
        }
        /// <summary>
        /// Metoda pobierająca teksturę
        /// </summary>
        /// <param name="name">nazwa tekstury</param>
        /// <returns>NULL</returns>
        public Texture GetTexture(string name)
        {
            if (textures.ContainsKey(name))
                return textures[name];
            else return null;
        }
        /// <summary>
        /// Ładuje spirty z pliku
        /// </summary>
        /// <param name="name">nazwa tekstury</param>
        /// <param name="path">ścieżka do pliku</param>
        /// <param name="totalFrames">ilość klatek</param>
        public void LoadSpriteSheetFromFile(string name, string path, int totalFrames)
        {
            if (!spriteSheets.ContainsKey(name))
            {
                SpriteSheet spriteSheet = new SpriteSheet();
                spriteSheet.texture = new Texture(path);
                spriteSheet.TotalFrames = totalFrames;

                spriteSheets.Add(name, spriteSheet);
            }
        }
        /// <summary>
        /// Metoda pobierająca sprite
        /// </summary>
        /// <param name="name">Nazwa tekstury</param>
        /// <returns>NULL</returns>
        public SpriteSheet GetSpriteSheet(string name)
        {
            if (spriteSheets.ContainsKey(name))
                return spriteSheets[name];
            else return null;
        }
        /// <summary>
        /// Metoda pobierająca dźwięk z pliku
        /// </summary>
        /// <param name="name">Nazwa pliku</param>
        /// <param name="path">Ścieżka do pliku</param>
        /// <returns>TRUE</returns>
        public bool LoadSoundFromFile(string name, string path)
        {
            if (GetSound(name) == null)
            {
                SoundBuffer soundBuffer = new SoundBuffer(path);
                Sound s = new Sound(soundBuffer);
                sound.Add(name, s);
                return true;
            }
            return true;
        }
        /// <summary>
        /// Pobiera dźwięk
        /// </summary>
        /// <param name="name">Nazwa pliku</param>
        /// <returns>NULL</returns>
        public Sound GetSound(string name)
        {
            if (sound.ContainsKey(name))
                return sound[name];
            else return null;
        }
        /// <summary>
        /// Metoda odtwarzająca muzykę
        /// </summary>
        /// <param name="name">Nazwa pliku</param>
        public void PlaySound(string name)
        {
            if (sound.ContainsKey(name))
                sound[name].Play();
        }
        /// <summary>
        /// Metoda zatrzymująca odtwarzanie muzyki 
        /// </summary>
        /// <param name="name">Nazwa pliku</param>
        public void StopSound(string name)
        {
            if (sound.ContainsKey(name))
                sound[name].Stop();
        }
    }
}
