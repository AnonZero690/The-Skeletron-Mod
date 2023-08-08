using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TheSkeletronMod.Items.Ammo;

namespace TheSkeletronMod.projectiles
{
    internal class SharpenedBoneProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 5;
        }
        public override void SetDefaults()
        {
            Projectile.width = 8;
            Projectile.height = 8;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 600;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
        }
        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            if (Projectile.ai[1] > 0)
            {
                if (Projectile.penetrate < 3)
                {
                    Projectile.maxPenetrate = 3;
                    Projectile.penetrate = 3;
                }
                Projectile.ai[1] = 0;
                Projectile.ai[0] = -5;
            }
            Projectile.ai[0]++;
            if (Projectile.ai[0] > 10)
                Projectile.velocity.Y += .25f;
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Projectile.DrawTrail(lightColor);
            return base.PreDraw(ref lightColor);
        }
    }
}