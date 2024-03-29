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
    public class CoinBox : DefaultEntity
    {
        private bool bumping = false;
        public int bumpCount = 5;

        /**\brief Konstruktor obiektu CoinBox korzystający z klasy DefaultEntity z solucji GameEngine
         */
        public CoinBox(GameObject gameObject) : base(gameObject, "coinbox")
        {
            this.GetEntitySpriteSheet().DefineFrames(Direction.NONE, new int[] { 0,1, 2 });
            //this.AutoCycleStaticSpriteSheet = false;
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
        /**Funkcja odpowiadająca za kolizję z graczem oraz zmianę tekstury bloku wraz z dodawaniem punktów
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
                    ResourceManager.GetInstance().GetSound("coin").Play();
                    e.Y = this.Y + this.sprite.TextureRect.Height;
                    e.Velocity = 5;
                    Velocity = -20;
                    bumping = true;
                    bumpCount--;
                    ((MainScene)gameObject.SceneManager.CurrentScene).IncreaseScore(100);
                    if (bumpCount == 0)
                    {
                        Entity c = new Characters.EmptyCoinBox(this.gameObject);
                        c.X = this.X;
                        c.Y = this.Y;
                        c.OriginTileCol = this.OriginTileCol;
                        c.OriginTileRow = this.OriginTileRow;
                        ((MainScene)base.gameObject.SceneManager.CurrentScene).Entities.Add(c);
                        Tile t = new Tile();
                        t.Entity = "emptycoinbox";
                        t.Frames = 1;
                        t.ID = 12;
                        t.Resource = "emptycoinbox";
                        t.Static = true;
                        ((MainScene)base.gameObject.SceneManager.CurrentScene).level.Tiles[c.OriginTileRow, c.OriginTileCol] = t;
                        this.Delete = true;
                    }
                    else
                    {
                        Characters.CoinBounce c = new Characters.CoinBounce(this.gameObject);
                        c.X = this.X;
                        c.Y = this.Y;
                        c.OriginTileCol = this.OriginTileCol;
                        c.OriginTileRow = this.OriginTileRow - 2;
                        c.IsStatic = true;
                        ((MainScene)base.gameObject.SceneManager.CurrentScene).Entities.Add(c);

                    }
                }
            }

            base.OnCharacterCollision(e, d);
        }
    }
}
