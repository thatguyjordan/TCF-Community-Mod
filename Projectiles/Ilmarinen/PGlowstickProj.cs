using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

using TAPI;
using Terraria;

namespace tcfcomm.Projectiles
{
    public class PGlowstickProj : ModProjectile
    {
        public override void PostAI()
        {
            if (projectile.wet)
            {
                projectile.velocity.Y = -1.2f;
                projectile.velocity.X /= 1.05f;
            }
        }
    }
}