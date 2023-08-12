using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace TheSkeletronMod.projectiles.Calcprojs.CalcRangeProj
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
            Projectile.width = Projectile.height = 32;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 600;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
        }
        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver4;
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
        public override void Kill(int timeleft)
        {
            Projectile.ownerHitCheck = true;






            Gore.NewGore(Projectile.GetSource_Death(), Projectile.Center, Vector2.Zero, Mod.Find<ModGore>("SharpenedBoneGore1").Type, 1f);



        }
    }
}