using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheSkeletronMod.projectiles.Calcprojs.CalcMeleeproj
{
    internal class SkullsplitterAxeProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 19;
        }
        public override void SetDefaults()
        {
            Projectile.width = 88;
            Projectile.height = 93;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 999;
        }

        public void frameCounter()
        {
            if (++Projectile.frameCounter >= 3)
            {
                Projectile.frameCounter = 0;
                Projectile.frame += 1;
                if (Projectile.frame >= Main.projFrames[Projectile.type])
                {
                    Projectile.frame = 0;
                }
            }
        }
    }
}
