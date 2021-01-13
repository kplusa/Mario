using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace GameEngine
{
    /// <summary>
    /// Enumeracja
    /// </summary>
    public enum Direction
    {
        NONE,
        UP,
        DOWN,
        RIGHT,
        LEFT,
        JUMPRIGHT,
        JUMPLEFT
    }
    /// <summary>
    /// Struktura pomocnicza dla spritów
    /// </summary>
    public struct SpriteFrame
    {
        public int currentframepointer;
        public int[] frames;
    }


    public class SpriteSheet
    {
        public Texture texture;
        public int TotalFrames = 1;
        public Dictionary<Direction, SpriteFrame> SpriteFrames = new Dictionary<Direction, SpriteFrame>();
        /// <summary>
        /// Metoda zwracająca wysokość klatki
        /// </summary>
        private int frameWidth
        {
            get { return (int)texture.Size.X / TotalFrames; }
        }
        /**\brief Konstruktor klasy SpriteSheet
         */
        public SpriteSheet()
        {
        }
        /// <summary>
        /// Metoda definiująca klatki
        /// </summary>
        /// <param name="d">kierunek</param>
        /// <param name="frames">tablica klatek</param>
        public void DefineFrames(Direction d, int[] frames)
        {
            SpriteFrame sf = new SpriteFrame() { currentframepointer = 0, frames = frames };
            
            if (SpriteFrames.ContainsKey(d))
                SpriteFrames.Remove(d);

            SpriteFrames.Add(d, sf);
        }
        /// <summary>
        /// Metoda pobierająca sprity z pliku
        /// </summary>
        /// <param name="d">kierunek</param>
        /// <param name="index">numer spritu</param>
        /// <returns>SPRITE</returns>
        public IntRect GetSprite(Direction d, int index)
        {
            SpriteFrame sf = SpriteFrames[d];

            if (index >= sf.frames.Length)
                sf.currentframepointer = 0;
            else
                sf.currentframepointer = index;

            SpriteFrames[d] = sf;

            return new IntRect(frameWidth * sf.frames[sf.currentframepointer], 0, frameWidth, (int)texture.Size.Y);

        }
        /// <summary>
        /// Metoda pobierająca początkowy sprite
        /// </summary>
        /// <param name="d">kierunek</param>
        /// <returns>SPRITE</returns>
        public IntRect GetFirstSprite(Direction d)
        {
            SpriteFrame sf = SpriteFrames[d];
            sf.currentframepointer = 0;
            SpriteFrames[d] = sf;

            return new IntRect(frameWidth * sf.frames[sf.currentframepointer], 0, frameWidth, (int)texture.Size.Y);
        }
        /// <summary>
        /// Metoda pobierająca kolejne sprite
        /// </summary>
        /// <param name="d">kierunek</param>
        /// <returns>SPRITE</returns>
        public IntRect GetNextSprite(Direction d)
        {
            SpriteFrame sf = SpriteFrames[d];
            sf.currentframepointer++;

            if (sf.currentframepointer >= sf.frames.Length)
                sf.currentframepointer = 0;

            SpriteFrames[d] = sf;

            return new IntRect(frameWidth * sf.frames[sf.currentframepointer], 0, frameWidth, (int)texture.Size.Y);
        }
    }


}
