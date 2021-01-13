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
    public class Coin : DefaultEntity
    {
        /**\brief Konstruktor obiektu Coin korzystający z klasy DefaultEntity z solucji GameEngine
         */
        public Coin(GameObject gameObject): base(gameObject,"coin")
        {
            this.GetEntitySpriteSheet().DefineFrames(Direction.NONE, new int[] { 0});
            this.IsAffectedByGravity = false;
            this.AutoCycleStaticSpriteSheet = false;
        }
        /**Funkcja odpowiadająca za kolizję z graczem
        * @param e obiekt gracza
        * @param d kierunek poruszania się
            */
        public override void OnCharacterCollision(Entity e, Direction d)
        {
            if (this.Delete)
                return;
            if (e.IsPlayer && e.HasUpwardVelocity)
            {
                if (this.Y + this.sprite.TextureRect.Height <= e.Y + Math.Abs(e.Velocity))
                {
                    this.Delete = true;
                }
            }
            base.OnCharacterCollision(e, d);
        }


    }
}
