using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.Common.Utils;

namespace TheSkeletronMod.Content.Projectiles.Calcprojs.CalcMeleeproj
{
    class BonerangReturnProjectileBottomHalf : ModProjectile
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
            Projectile.rotation += 0.17f;
            if (Projectile.Center.InRange(target, 64))
            {
                Projectile.Kill();
            }
            else
            {
                Projectile.velocity = ((Projectile.velocity + Vector2.Normalize(target - Projectile.Center) * 3) * 0.85f).LimitLength(24f);
            }
        }
    }
}
