using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;

namespace TheSkeletronMod.projectiles.Calcprojs.CalcMeleeproj
{
    public class BoneSwordP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 200;
            Projectile.timeLeft = 60;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.light = 10f;
            Projectile.DamageType = ModContent.GetInstance<Bonecursed>();
        }

        int progress = 0;
        int maxProgress = 30;
        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation();
            progress += 1;
            if (progress > maxProgress)
            {
                Projectile.velocity = Projectile.velocity * -1;
                progress = -10000;
            }
        }
    }
}
