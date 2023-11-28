using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.Common.Utils;
using TheSkeletronMod.Content.Projectiles.Calcprojs.OtherProj;

namespace TheSkeletronMod.Content.Projectiles.Calcprojs.CalcMageproj
{
    
    public class AirstrikeBone : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.BoneArrow);
            Projectile.width = 22;
            Projectile.height = 22;
            Projectile.tileCollide = true;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = ModContent.GetInstance<Bonecursed>();
            Projectile.penetrate = -1;
            Projectile.timeLeft = 1800;
        }
        //public override void AI()
        //{
        //    float OGCursorPosY = Main.MouseWorld.Y;

        //    if (Projectile.position.Y < OGCursorPosY)
        //    {
        //        Projectile.tileCollide = true;
        //    }
        //}
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.velocity = Vector2.Zero;
            return false;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.timeLeft -= damageDone * 2;
            if (hit.Crit == true)
            {
                Projectile.timeLeft += damageDone;
            }
        }
        public override void OnKill(int timeLeft)
        {
            // Check if the projectile is about to disappear naturally or due to hitting a tile
            if (Projectile.timeLeft <= 0)
            {
                // Explode or perform actions when the projectile dies
                VisualExplosion(); // also handles audio, guess I'm really bad at naming things
                int explosionDamage = Projectile.NewProjectile(Projectile.GetSource_FromThis(),Projectile.position,Vector2.Zero,ModContent.ProjectileType<VeryBigDamageHitbox>(),100,0);
            }
        }
        private void VisualExplosion()
        {
            //for (int g = 0; g < 2; g++) // large smoke gore
            //{
                //var goreSpawnPosition = new Vector2(Projectile.position.X + Projectile.width / 2 - 24f, Projectile.position.Y + Projectile.height / 2 - 24f);
                //Gore gore = Gore.NewGoreDirect(Projectile.GetSource_FromThis(), goreSpawnPosition, default, Main.rand.Next(61, 64), 1f);
                //gore.scale = 1.5f;
                //gore.velocity.X += 1.5f;
                //gore.velocity.Y += 1.5f;
                //gore = Gore.NewGoreDirect(Projectile.GetSource_FromThis(), goreSpawnPosition, default, Main.rand.Next(61, 64), 1f);
                //gore.scale = 1.5f;
                //gore.velocity.X -= 1.5f;
                //gore.velocity.Y += 1.5f;
                //gore = Gore.NewGoreDirect(Projectile.GetSource_FromThis(), goreSpawnPosition, default, Main.rand.Next(61, 64), 1f);
                //gore.scale = 1.5f;
                //gore.velocity.X += 1.5f;
                //gore.velocity.Y -= 1.5f;
                //gore = Gore.NewGoreDirect(Projectile.GetSource_FromThis(), goreSpawnPosition, default, Main.rand.Next(61, 64), 1f);
                //gore.scale = 1.5f;
                //gore.velocity.X -= 1.5f;
                //gore.velocity.Y -= 1.5f;
            //}
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position); // sound
            for (int i = 0; i < 50; i++) // small smoke dust
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, default, 1f);
                dust.velocity *= 1.4f;
            }

            for (int i = 0; i < 30; i++) // fire dust (careful, it's hot)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 2f);
                dust.noGravity = true;
                dust.velocity *= 5f;
                dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 1f);
                dust.velocity *= 3f;
            }
        }
    }
}