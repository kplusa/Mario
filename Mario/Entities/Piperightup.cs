﻿using System;
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
    class Piperightup : DefaultEntity
    {
        /**\brief Konstruktor obiektu Piperightup korzystający z klasy DefaultEntity z solucji GameEngine
         */
        public Piperightup(GameObject gameObject) : base(gameObject, "piperightup")
        {
            this.GetEntitySpriteSheet().DefineFrames(Direction.NONE, new int[] { 0 });
        }


    }
}



