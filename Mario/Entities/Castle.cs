using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine;

namespace Mario.Characters
{
    class Castle:Entity
    {
        /**\brief Konstruktor obiektu Castle korzystający z klasy DefaultEntity z solucji GameEngine
         */
        public Castle(GameObject gameObject) : base(gameObject)
        {
            this.Name = "castle";
            this.EntitySpriteSheet = ResourceManager.GetInstance().GetSpriteSheet("castle");
            this.EntitySpriteSheet.DefineFrames(Direction.NONE, new int[] { 0 });
            this.Facing = Direction.NONE;
            this.IsPlayer = false;
            this.IsStatic = true;
            this.Acceleration = 0;
            this.AllowOffscreen = false;
        }
    }
}
