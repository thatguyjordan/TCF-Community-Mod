using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

using TAPI;
using Terraria;

namespace tcfcomm.Projectiles
{
    public class Explosion : ModProjectile
    {
        public override void PostAI()
        {
            projectile.tileCollide = false;
            projectile.ai[1] = 0f;
            projectile.alpha = 255;
            projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
            projectile.width = 160;
            projectile.height = 160;
            projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
            projectile.damage = 150;
            projectile.knockBack = 13f;        
        }
    }
}