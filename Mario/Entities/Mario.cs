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
    public class Mario : DefaultEntity
    {
     
        public bool IsOnFlagpole = false;
        /**\brief Konstruktor obiektu MArio korzystający z klasy DefaultEntity z solucji GameEngine
         */
        public Mario(GameObject gameObject) : base(gameObject,"mario", 192, 576)
        {
            this.GetEntitySpriteSheet().DefineFrames(Direction.RIGHT, new int[] { 5, 6, 7, 9 });
            this.GetEntitySpriteSheet().DefineFrames(Direction.LEFT, new int[] { 4, 3, 2, 0 });
            this.GetEntitySpriteSheet().DefineFrames(Direction.JUMPRIGHT, new int[] { 8 });
            this.GetEntitySpriteSheet().DefineFrames(Direction.JUMPLEFT, new int[] { 1 });
        }
        /**Funkcja odpowiadająca za ruch Mario*/
        public override void Update()
        {
            if (this.Y > this.gameObject.Window.Size.Y - 64)
                Die();
            base.Update();
        }
        /**Funkcja odpowiadająca za kolizję z obiektami
        * @param e obiekt gracza
        * @param d kierunek poruszania się
            */
        public override void OnCharacterCollision(Entity e, Direction d)
        {
            if (e.IsStatic || e.IgnorePlayerCollisions)
                return;

            if (this.Y < e.Y)
            {  

                e.Delete = true;
                this.IsJumping = true;
                this.Velocity = -45;
            }
            else
            {

                if (e.GetType() != typeof(Flag))

                if (e.GetType() != typeof(Headflag))

                    Die();
            }
        }
        /**Funkcja odpowiadająca za zachowanie gry po kolizji*/
        public void Die()
        {
            this.IsMoving = false;
            ResourceManager.GetInstance().GetSound("die").Play();
            ResourceManager.GetInstance().StopSound("music");
            while (ResourceManager.GetInstance().GetSound("die").Status == SFML.Audio.SoundStatus.Playing)
            { }
            ((MainScene)gameObject.SceneManager.CurrentScene).Lives--;
            if (((MainScene)gameObject.SceneManager.CurrentScene).Lives == 0)
                gameObject.SceneManager.StartScene("gameover");
            else
                gameObject.SceneManager.StartScene("start");
        }

    }
}
