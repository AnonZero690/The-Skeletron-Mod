using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheSkeletronMod.Content.Projectiles.Calcprojs.OtherProj
{
    public class VeryBigDamageHitbox : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.BloodArrow);
            Projectile.width = 100;
            Projectile.height = 100;
            Projectile.damage = 100;
            Projectile.timeLeft = 100;
        }
        public override bool OnTileCollide(Microsoft.Xna.Framework.Vector2 oldVelocity)
        {
            return false;
        }
    }
}
