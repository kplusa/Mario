using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine;
using SFML.Graphics;
using SFML.Window;
using SFML.Audio;
namespace Mario.Characters
{
    class Pipeleft : DefaultEntity
    {
        /**\brief Konstruktor obiektu Pipeleft korzystający z klasy DefaultEntity z solucji GameEngine
         */
        public Pipeleft(GameObject gameObject) : base(gameObject, "pipeleft")
        {
            this.GetEntitySpriteSheet().DefineFrames(Direction.NONE, new int[] { 0 });
        }
    }
}



