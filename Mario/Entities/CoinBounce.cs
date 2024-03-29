﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine;
using SFML.Graphics;
using SFML.Window;
using SFML.Audio;
using SFML.System;

namespace Mario.Characters
{
    public class CoinBounce : DefaultEntity
    {
        /**\brief Konstruktor obiektu CoinBounce korzystający z klasy DefaultEntity z solucji GameEngine
         */
        public CoinBounce(GameObject gameObject) : base(gameObject, "coinbounce")
        {
            this.GetEntitySpriteSheet().DefineFrames(Direction.NONE, new int[] { 0, 1, 2, 3, 4, 5 });
            this.AutoCycleStaticSpriteSheet = true;
        }
        /**Funkcja odpowiadająca za ruch uderzonego bloku*/
        public override void Update()
        {
            base.Update();
            if (this.GetEntitySpriteSheet().SpriteFrames[Direction.NONE].currentframepointer == 0)
                this.Delete = true;
        }

    }
}
