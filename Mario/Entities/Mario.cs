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
    public class Mario : CharacterEntity
    {
        

        public bool IsOnFlagpole = false;

        public Mario(GameObject gameObject) : base(gameObject)
        {
            this.Name = "mario";
            this.SetEntitySpriteSheet(ResourceManager.GetInstance().GetSpriteSheet("mario"));
            this.GetEntitySpriteSheet().DefineFrames(Direction.RIGHT, new int[] { 5, 6, 7, 9 });
            this.GetEntitySpriteSheet().DefineFrames(Direction.LEFT, new int[] { 4, 3, 2, 0 });
            this.GetEntitySpriteSheet().DefineFrames(Direction.JUMPRIGHT, new int[] { 8 });
            this.GetEntitySpriteSheet().DefineFrames(Direction.JUMPLEFT, new int[] { 1 });
            this.IsPlayer = true;
            this.Facing = Direction.RIGHT;
            this.X = 192;
            this.Y = 640;
            this.Acceleration = 10;
            this.AllowOffscreen = false;
        }

        public override void Update()
        {
            base.Update();
        }


    }
}
