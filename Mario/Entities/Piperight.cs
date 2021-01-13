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
    class Piperight : DefaultEntity
    {
        /**\brief Konstruktor obiektu Piperight korzystający z klasy DefaultEntity z solucji GameEngine
         */
        public Piperight(GameObject gameObject) : base(gameObject, "piperight")
        {
            this.GetEntitySpriteSheet().DefineFrames(Direction.NONE, new int[] { 0 });
        }


    }
}



