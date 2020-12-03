using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine;

namespace Mario.Characters
{
    public class Headflag : DefaultEntity
    {
        public Headflag(GameObject gameObject): base(gameObject,"headflag")
        {
            this.EntitySpriteSheet.DefineFrames(Direction.NONE, new int[] { 0, 0, 0, 1, 1, 1, 2, 2, 2 });
            this.IsAffectedByGravity = false;
            this.AutoCycleStaticSpriteSheet = true;
        }
        public override void Update()
        {
            base.Update();

        }

       
    }
}
