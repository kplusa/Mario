using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine;

namespace Mario.Characters
{
    public class Flag : DefaultEntity
    {
        public Flag(GameObject gameObject) : base(gameObject, "flag")
        {
            this.GetEntitySpriteSheet().DefineFrames(Direction.NONE, new int[] { 0});
            this.IsAffectedByGravity = false;
        }
        public override void OnCharacterCollision(Entity e, Direction d)
        {
            if (e.IsPlayer)
            {
                Mario m = (Mario)e;

                if (m.IsOnFlagpole)
                {
                    m.IsJumping = true;
                    m.Acceleration = 0;
                    m.Velocity = 5;
                    m.X = this.X;
                    Flag f = (Flag)this.gameObject.SceneManager.CurrentScene.Entities.Find(x => x.Name == "flag");
                    f.IsAffectedByGravity = true;
                    f.Velocity = 10;
                    f.IgnorePlayerCollisions = true;
                    f.IsStatic = false;
                }
                else
                {
                    m.IsMoving = false;
                    m.IsOnFlagpole = true;

                }
            }
        }
    }
}
