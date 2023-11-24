using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace TheSkeletronMod.projectiles.Calcprojs.CalcMeleeproj
{
    internal class SkullsplitterAxeProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 19;
            //sobbing time
        }
        public override void SetDefaults()
        {
            Projectile.width = 88;
            Projectile.height = 93;
            Projectile.penetrate = 0;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 999;
            Projectile.knockBack = 10;
        }
        const int maxFramesPerAnimFrame = 5;
        int framesPerAnimFrame = 0;
        public override void AI()
        {
            int player = Projectile.owner;
            framesPerAnimFrame++;
            if (framesPerAnimFrame ==  maxFramesPerAnimFrame)
            {
                if (Projectile.frame == 19)
                {
                    Projectile.Kill();
                }
                framesPerAnimFrame = 0;
                Projectile.frame++;
            }

            Projectile.position = Main.player[player].position - new Vector2(60,45);

        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            //no u
            target.AddBuff(BuffID.BrokenArmor, 100);
        }
    }
}
