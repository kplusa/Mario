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
    public class Brick : DefaultEntity
    {
        private bool bumping = false;
        /**\brief Konstruktor obiektu Brick korzystający z klasy DefaultEntity z solucji GameEngine
         */
        public Brick(GameObject gameObject) : base(gameObject,"brick")
        {
            this.GetEntitySpriteSheet().DefineFrames(Direction.NONE, new int[] { 0 });
        }
        /**Funkcja odpowiadająca za ruch uderzonego bloku*/
        public override void Update()
        {
            base.Update();

            if (bumping)
            {
                Velocity += 5;
                if (Velocity == 0)
                    bumping = false;
            }
            else
                Velocity = 0;
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
                    Velocity = -20;
                    bumping = true;
                }
            }
            base.OnCharacterCollision(e, d);
        }
    }
    }

