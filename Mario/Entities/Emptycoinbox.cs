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
    public class EmptyCoinBox : DefaultEntity
    {
        /**\brief Konstruktor obiektu EmptyCoinBox korzystający z klasy DefaultEntity z solucji GameEngine
         */
        public EmptyCoinBox(GameObject gameObject) : base(gameObject, "emptycoinbox")
        {
            this.GetEntitySpriteSheet().DefineFrames(Direction.NONE, new int[] { 0 });
        }

        /**Funkcja odpowiadająca za kolizję z graczem
       * @param e obiekt gracza
       * @param d kierunek poruszania się
           */
        public override void OnCharacterCollision(Entity e, Direction d)
        {
            if (e.IsPlayer && e.HasUpwardVelocity)
            {
                if (this.Y + this.sprite.TextureRect.Height <= e.Y + Math.Abs(e.Velocity))
                {
                    ResourceManager.GetInstance().GetSound("bump").Play();
                    e.Y = this.Y + this.sprite.TextureRect.Height;
                    e.Velocity = 5;
                }
            }

            base.OnCharacterCollision(e, d);

        }


    }
}
