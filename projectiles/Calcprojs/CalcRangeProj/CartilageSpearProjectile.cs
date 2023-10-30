using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace TheSkeletronMod.projectiles.Calcprojs.CalcRangeProj
{
    internal class CartilageSpearProjectile : ModProjectile
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
            Projectile.penetrate = 100;
            Projectile.timeLeft = 600;
            Projectile.extraUpdates = 1;
            Projectile.light = 0;
        }
        public override void AI()
        {
            if (Main.rand.NextBool(1))
            {
                int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Bone, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
                Main.dust[dust].scale *= 0.25f;
                Main.dust[dust].noGravity = true;
            }
        }
        public override void OnKill(int timeleft)

        {
            for (int i = 0; i < 130; i++)
            {
                Vector2 speed = Main.rand.NextVector2CircularEdge(1f, 1f);
                var d = Dust.NewDustPerfect(Projectile.Center, DustID.Bone, speed * 8, Scale: 0.5f);
                ;
                d.noGravity = true;
            }
            Player player = Main.player[Projectile.owner];

            Projectile.NewProjectile(Projectile.GetSource_Death(), Projectile.Center.X, Projectile.Center.Y, 40, 0, ModContent.ProjectileType<CartilageSpearShrapnelProj>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
            Projectile.NewProjectile(Projectile.GetSource_Death(), Projectile.Center.X, Projectile.Center.Y, -40, 0, ModContent.ProjectileType<CartilageSpearShrapnelProj>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
            Projectile.NewProjectile(Projectile.GetSource_Death(), Projectile.Center.X, Projectile.Center.Y, 0, -40, ModContent.ProjectileType<CartilageSpearShrapnelProj>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);

            for (int i = 0; i < 17; i++)
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Stone, 0f, 0f, 50, default, 0.8f);

            Collision.AnyCollision(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item1, Projectile.position);


            int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Bone, 0f, 0f, 100, default, 0.5f);

            Main.dust[dustIndex].noGravity = false;
            Main.dust[dustIndex].position = Projectile.Center + new Vector2(0f, (float)(-(float)Projectile.height / 2)).RotatedBy(Projectile.rotation, default) * 1.1f;
            Main.dust[dustIndex].noLight = false;

            int dustIndex1 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Bone, 0f, 0f, 255, default, 0.5f);

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