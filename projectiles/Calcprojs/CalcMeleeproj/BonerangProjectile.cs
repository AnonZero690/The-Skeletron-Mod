using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TheSkeletronMod.Common.DamageClasses;

namespace TheSkeletronMod.projectiles.Calcprojs.CalcMeleeproj
{
    class BonerangProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = Projectile.height = 30;
            Projectile.DamageType = ModContent.GetInstance<Bonecursed>();
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.timeLeft = 999;
            Projectile.tileCollide = true;
        }
        public override void AI()
        {
            if(Projectile.timeLeft == 999)
            {
                Projectile.ai[0] = 90;
                Projectile.velocity = (Main.MouseWorld - Main.player[Projectile.owner].Center).SafeNormalize(Vector2.Zero) * 9f;
            }
            Projectile.ai[0]--;
            Projectile.rotation += 0.17f;
            if (Projectile.ai[0] < 1)
            {
                ReturnFunction(Projectile.velocity);
                Projectile.Kill();
            }
        }
        public override void OnKill(int timeLeft)
        {
            ReturnFunction(Projectile.velocity);
        }
        private void ReturnFunction(Vector2 v)
        {
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, -v.RotatedBy(Math.PI / 10), ModContent.ProjectileType<BonerangReturnProjectile>(), 15, 4f, Projectile.owner);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, -v.RotatedBy(-Math.PI / 10), ModContent.ProjectileType<BonerangReturnProjectile>(), 15, 4f, Projectile.owner);
        }
    }
}