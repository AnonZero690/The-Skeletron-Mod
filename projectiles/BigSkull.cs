using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheSkeletronMod.projectiles
{

    public class BigSkull : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            Projectile.width = 50;
            Projectile.height = 50;

            Projectile.aiStyle = 0;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.light = 0.2f;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 600;
            Projectile.penetrate = 1;
            Projectile.extraUpdates = 1;
            Projectile.damage = 40;


        }
        public override void AI()
        {

            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Bone, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f, Scale: 1.5f);
            Projectile.aiStyle = 1;
            Lighting.AddLight(Projectile.position, 0.1f, 0.1f, 0.1f);
            Lighting.Brightness(1, 1);

          
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

            Gore.NewGore(Projectile.GetSource_Death(), Projectile.Center, Vector2.Zero, Mod.Find<ModGore>("BigSkullGore1").Type, 1f);
            Gore.NewGore(Projectile.GetSource_Death(), Projectile.Center, Vector2.Zero, Mod.Find<ModGore>("BigSkullGore2").Type, 1f);
            Gore.NewGore(Projectile.GetSource_Death(), Projectile.Center, Vector2.Zero, Mod.Find<ModGore>("BigSkullGore3").Type, 1f);

            for (int i = 0; i < 80; i++)
            {
                Vector2 speed = Main.rand.NextVector2CircularEdge(3f, 3f);
                var d = Dust.NewDustPerfect(Projectile.Center, DustID.Bone, speed * 5, Scale: 2f);
                ;
                d.noGravity = true;
            }

            SoundEngine.PlaySound(SoundID.DD2_SkeletonDeath);
        }
    }
}

