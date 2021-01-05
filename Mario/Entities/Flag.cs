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
<<<<<<< HEAD
            this.GetEntitySpriteSheet().DefineFrames(Direction.NONE, new int[] { 0});
            this.IsAffectedByGravity = false;
=======
            this.GetEntitySpriteSheet().DefineFrames(Direction.NONE, new int[] { 0 });


>>>>>>> tmp
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
<<<<<<< HEAD
                    Flag f = (Flag)this.gameObject.SceneManager.CurrentScene.Entities.Find(x => x.Name == "flag");
                    f.IsAffectedByGravity = true;
                    f.Velocity = 10;
                    f.IgnorePlayerCollisions = true;
                    f.IsStatic = false;
=======

                    Headflag hf = (Headflag)this.gameObject.SceneManager.CurrentScene.Entities.Find(x => x.Name == "headflag");
                    hf.IsAffectedByGravity = true;
                    hf.Velocity = 10;
                    hf.IgnorePlayerCollisions = true;
                    hf.IsStatic = false;
                    if (this.Y == hf.Y)
                    {

                        while (ResourceManager.GetInstance().GetSound("end_map").Status == SFML.Audio.SoundStatus.Playing)
                        { }
                        gameObject.SceneManager.StartScene("win");
                    }




>>>>>>> tmp
                }
                else
                {
                    m.IsMoving = false;
                    ResourceManager.GetInstance().GetSound("end_map").Play();
                    ResourceManager.GetInstance().StopSound("music");
                    m.IsOnFlagpole = true;

                }
            }
        }
    }
}
