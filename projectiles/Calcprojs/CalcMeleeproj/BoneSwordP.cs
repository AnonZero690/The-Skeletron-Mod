using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
using System;

namespace TheSkeletronMod.projectiles.Calcprojs.CalcMeleeproj
{
    public class BoneSwordP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 130;
            Projectile.height = 142;
            Projectile.timeLeft = 600;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.light = 2f;
            Projectile.DamageType = ModContent.GetInstance<Bonecursed>();
            Projectile.stopsDealingDamageAfterPenetrateHits = true;
        }
        public override void AI()
        {
            if (Projectile.timeLeft > 100)
            {
                Projectile.timeLeft = 100;
            }
            float progress = (100 - Projectile.timeLeft) / 100f;
            Projectile.alpha = (int)MathHelper.Lerp(0, 255, progress);
            Projectile.rotation = Projectile.velocity.ToRotation();
            Vector2 vel = -Projectile.velocity.SafeNormalize(Vector2.Zero);
            float scaling = MathHelper.Lerp(2.5f, .25f, progress);
            for (int i = 0; i < 7; i++)
            {
                int dust = Dust.NewDust(Projectile.Center.PositionOFFSET(vel, Main.rand.Next(-75, -60)) + Main.rand.NextVector2Circular(10, 10), 0, 0, DustID.WhiteTorch);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity = 
                    vel.RotatedBy(MathHelper.PiOver2 * Main.rand.NextBool().BoolOne()) * Main.rand.NextFloat(1f, 20f);
                Main.dust[dust].scale = Math.Clamp(Main.rand.NextFloat(.5f, 1.5f), 0, scaling);
                int dust1 = Dust.NewDust(Projectile.Center.PositionOFFSET(vel, Main.rand.Next(-75, -60)) + Main.rand.NextVector2Circular(10, 10), 0, 0, DustID.PurpleTorch);
                Main.dust[dust1].noGravity = true;
                Main.dust[dust1].velocity = 
                    vel.RotatedBy(MathHelper.PiOver2 * Main.rand.NextBool().BoolOne()) * Main.rand.NextFloat(1f, 20f);
                Main.dust[dust1].scale = Math.Clamp(Main.rand.NextFloat(.5f, 1.5f), 0, scaling);
                int dust2 = Dust.NewDust(Projectile.Center + Main.rand.NextVector2Circular(70, 70), 0, 0, DustID.WhiteTorch, newColor: Color.Black);
                Main.dust[dust2].noGravity = true;
                Main.dust[dust2].velocity = vel;
                Main.dust[dust2].scale = Math.Clamp(Main.rand.NextFloat(1, 2.5f), 0, scaling);
            }
        }
    }
}
