using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TheSkeletronMod.Common.DamageClasses;

namespace TheSkeletronMod.projectiles.Calcprojs.CalcMeleeproj
{
    class BonerangReturnProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = Projectile.height = 32;
            Projectile.friendly = true;
            Projectile.damage = 15;
            Projectile.DamageType = ModContent.GetInstance<Bonecursed>();
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
        }
        public override void AI()
        {
            Vector2 target = Main.player[Projectile.owner].Center;
            if (Projectile.Center.IsCloseToPosition(target, 64))
            {
                Projectile.Kill();
            }
            else
            {
                target = Vector2.Normalize(target - Projectile.Center);
                Projectile.velocity += target * 3f;
                Projectile.velocity *= 0.85f;
                if(Projectile.velocity.IsLimitReached(24))
                {
                    Projectile.velocity = Vector2.Normalize(Projectile.velocity) * 24f;
                }
            }
        }
    }
}
