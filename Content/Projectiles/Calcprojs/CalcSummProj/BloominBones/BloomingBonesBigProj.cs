using System;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace TheSkeletronMod.Content.Projectiles.Calcprojs.CalcSummProj.BloominBones
{
    public class BloomingBonesBigProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 180;
        }

        public override void AI()
        {
            float angle = MathHelper.ToRadians(80);
            Projectile.velocity = new Vector2((float)Math.Cos(angle) * Projectile.velocity.Length(), (float)Math.Sin(angle) * Projectile.velocity.Length());
            Projectile.velocity.Y += 0.2f;
        }
    }
}
