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
        Dictionary<string, Texture> _textures = new Dictionary<string, Texture>();
        Dictionary<string, SpriteSheet> _spriteSheets = new Dictionary<string, SpriteSheet>();

        public static ResourceManager GetInstance()
        {
            if (instance == null)
            {
                instance = new ResourceManager();
            }
            return instance;
        }

        public void LoadTexture(string name, string path)
        {
            if(GetTexture(name) == null)
            { 
                Texture texture = new Texture(path);
                _textures.Add(name, texture);
            }
        }

        public Texture GetTexture(string name)
        {
            if (_textures.ContainsKey(name))
                return _textures[name];
            else return null;
        }

        public void LoadSpriteSheetFromFile(string name, string path, int totalFrames)
        {
            if (!_spriteSheets.ContainsKey(name))
            {
                SpriteSheet spriteSheet = new SpriteSheet();
                spriteSheet.texture = new Texture(path);
                spriteSheet.TotalFrames = totalFrames;

                _spriteSheets.Add(name, spriteSheet);
            }
        }

        public SpriteSheet GetSpriteSheet(string name)
        {
            if (_spriteSheets.ContainsKey(name))
                return _spriteSheets[name];
            else return null;
        }

    }
}
