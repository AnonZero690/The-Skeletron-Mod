using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TheSkeletronMod.Items.Weapons.Calcium;
using Terraria.ID;
using Terraria.Audio;

namespace TheSkeletronMod.projectiles
{
    internal class AncientBoneDartProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 5;
        }
        public override void SetDefaults()
        {
            Projectile.width = 12;

            Projectile.height = 18;
            Projectile.aiStyle = ProjAIStyleID.Arrow;
            Projectile.friendly = true;
            Projectile.penetrate = 2;
            Projectile.timeLeft = 600;
            Projectile.extraUpdates = 1;
            Projectile.light = 0;
        }
        public override void AI()
        {
            if (Main.rand.NextBool(1))
            {
                int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Bone, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
                Main.dust[dust].scale *= 1f;
                Main.dust[dust].noGravity = true;
            }
        }
        public override void Kill(int timeleft)

        {

            for (int i = 0; i < 17; i++)
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Stone, 0f, 0f, 50, default, 2f);

            Collision.AnyCollision(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item1, Projectile.position);


            int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Bone, 0f, 0f, 100, default, 1f);

            Main.dust[dustIndex].noGravity = false;
            Main.dust[dustIndex].position = Projectile.Center + new Vector2(0f, (float)(-(float)Projectile.height / 2)).RotatedBy(Projectile.rotation, default) * 1.1f;
            Main.dust[dustIndex].noLight = false;

            int dustIndex1 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Bone, 0f, 0f, 255, default, 3f);

            Main.dust[dustIndex1].noGravity = true;
            Main.dust[dustIndex1].position = Projectile.Center + new Vector2(0f, (float)(-(float)Projectile.height / 2)).RotatedBy(Projectile.rotation, default) * 1.1f;
            Main.dust[dustIndex1].noLight = false;
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Projectile.DrawTrail(lightColor);
            return base.PreDraw(ref lightColor);
        }
    }
}