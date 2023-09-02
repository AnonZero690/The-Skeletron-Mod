using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using TheSkeletronMod.Common.DamageClasses;
using System.Security.Cryptography.X509Certificates;
using Terraria.Utilities;
using Terraria.Audio;

namespace TheSkeletronMod.projectiles.Calcprojs.CalcMeleeproj
{
    public class SkeletalReaperP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 200;
            Projectile.timeLeft = 600;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 2;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.light = 10f;
            Projectile.DamageType = ModContent.GetInstance<Bonecursed>();
            Projectile.ArmorPenetration = 2;
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
            Projectile.rotation = Projectile.velocity.ToRotation();
            if (++Projectile.frameCounter >= 3f)//the amount of ticks the game spends on each frame
            {
                Projectile.frameCounter = 0;

                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                    Projectile.frame = 0;
            }
            //var dust = Dust.NewDustPerfect(Projectile.position + new Vector2(0, 100), DustID.TintableDust, Projectile.velocity/2);
            //dust.scale = 2.5f;
            //dust.fadeIn = 0.4f;
            //dust.noGravity = true;
            //dust.noLight = false;
            //dust.color = Color.Purple;
            //dust.alpha = 0;
        }
        public override void Kill(int timeleft)
        {
            Projectile.ownerHitCheck = true;

            int radius = 140;

            // Damage enemies within the splash radius
            for (int i = 0; i < Main.npc.Length; i++)
            {
                NPC target = Main.npc[i];
                if (target.active && !target.friendly && Vector2.Distance(Projectile.Center, target.Center) < radius)
                {
                    int damage = Projectile.damage * 3; // Deal half the projectile's damage as splash damage
                    target.SimpleStrikeNPC(50, 0);
                }
            }

            for (int a = 0; a < 80; a++)
            {
                Vector2 speed = Main.rand.NextVector2CircularEdge(3f, 3f);
                var d = Dust.NewDustPerfect(Projectile.Center, DustID.WhiteTorch, speed * 5, Scale: 4f);
                ;
                d.noGravity = true;
            }
            for (int b = 0; b < 80; b++)
            {
                Vector2 speed = Main.rand.NextVector2CircularEdge(3f, 3f);
                var d = Dust.NewDustPerfect(Projectile.Center, DustID.PurpleTorch, speed * 5, Scale: 6f);
                ;
                d.noGravity = true;
            }
            for (int i = 0; i < 80; i++)
            {
                Vector2 speed = Main.rand.NextVector2CircularEdge(3f, 3f);
                var d = Dust.NewDustPerfect(Projectile.Center, DustID.Bone, speed * 5, Scale: 3f);
                ;
                d.noGravity = true;
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
