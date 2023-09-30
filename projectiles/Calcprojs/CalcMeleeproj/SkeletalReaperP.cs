using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using TheSkeletronMod.Common.DamageClasses;
using Terraria.Audio;

namespace TheSkeletronMod.projectiles.Calcprojs.CalcMeleeproj
{
    public class SkeletalReaperP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 164;
            Projectile.height = 164;
            Projectile.timeLeft = 600;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 8;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.light = 10f;
            Projectile.DamageType = ModContent.GetInstance<Bonecursed>();
            Projectile.ArmorPenetration = 2;
            Projectile.stopsDealingDamageAfterPenetrateHits = true;
        }

        public override void SetStaticDefaults()
        {
            
            Main.projFrames[Projectile.type] = 7;
            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
        }
        public bool damageReduced = false;
        public override void AI()
        {
            if (damageReduced == false)
            {
                Projectile.damage -= 55;
                damageReduced = true;
            }

            for (int i = 0; i < 5; i++)
            {
                int dust = Dust.NewDust(Projectile.position, 150, 150, DustID.Shadowflame);
                Main.dust[dust].scale = Main.rand.NextFloat(.85f, 1.25f);
                Main.dust[dust].color = new Color(190,10,150);
                Main.dust[dust].noGravity = true;
            }
            Projectile.spriteDirection = Projectile.direction;
            Projectile.rotation = Projectile.velocity.ToRotation();
            if(Projectile.penetrate <= 0)
            {
                if(Projectile.timeLeft >= 20)
                {
                    Projectile.timeLeft = 20;
                }
                Projectile.alpha = (int)MathHelper.Lerp(0, 255, (20 - Projectile.timeLeft) / 20f);
                Projectile.velocity *= .9f;
            }
            if(Projectile.spriteDirection == -1)
            {
                Projectile.rotation += MathHelper.Pi;
            }
            if (++Projectile.frameCounter >= 3f)
            {
                Projectile.frameCounter = 0;

                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                    Projectile.frame = 0;
            }
        }
        public override void Kill(int timeleft)
        {
            Player player = Main.player[Projectile.owner];
            // Damage enemies within the splash radius
            Projectile.Center.LookForHostileNPC(out List<NPC> npclist, 140f);
            foreach (NPC npc in npclist)
            {
                player.StrikeNPCDirect(npc,npc.CalculateHitInfo(50, 0));
            }
            SoundEngine.PlaySound(SoundID.DD2_SkeletonDeath);
        }
        //public override void Kill(int timeLeft)
        //{
        //   for (int  i = 0;  i < 10;  i++)
        //   {
        //       var dust = Dust.NewDustPerfect(Projectile.position + new Vector2(0,100), DustID.TintableDust, new Vector2(-1, -1));
        //       dust.scale = 2.5f;
        //        dust.fadeIn = 0.4f;
        //        dust.noGravity = true;
        //        dust.noLight = false;
        //        dust.color = Color.Purple;
        //        dust.alpha = 0;
        //    }

        // }
    }
}
