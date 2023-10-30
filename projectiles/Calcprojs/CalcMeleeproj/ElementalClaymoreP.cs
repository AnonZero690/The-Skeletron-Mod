using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
using System;
using TheSkeletronMod.Buffs;

namespace TheSkeletronMod.projectiles.Calcprojs.CalcMeleeproj
{
    public class ElementalClaymoreP : ModProjectile
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
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            int timeToDebuff = 100;
            for (int i = 0; i < 1; i++)
            {
                int randomNumber = Main.rand.Next(1, 10);
                if (randomNumber == 1)
                {
                    target.AddBuff(BuffID.Burning, timeToDebuff);
                }
                if (randomNumber == 2)
                {
                    target.AddBuff(BuffID.CursedInferno, timeToDebuff);
                }
                if (randomNumber == 3)
                {
                    target.AddBuff(BuffID.Frostburn, timeToDebuff);
                }
                if (randomNumber == 4)
                {
                    target.AddBuff(BuffID.Venom, timeToDebuff);
                }
                if (randomNumber == 5)
                {
                    target.AddBuff(ModContent.BuffType<BonedDebuff>(), timeToDebuff); //change this to dungeon curse when it is added
                }
                if (randomNumber == 6)
                {
                    target.AddBuff(BuffID.Stinky, timeToDebuff);
                    i++;
                }
                if (randomNumber == 7)
                {
                    target.AddBuff(BuffID.WitheredWeapon, timeToDebuff);
                }
                if (randomNumber == 8)
                {
                    target.AddBuff(BuffID.ShadowFlame, timeToDebuff);
                }
                if (randomNumber == 9)
                {
                    target.AddBuff(BuffID.Electrified, timeToDebuff);
                }
            }
        }
    }
}
