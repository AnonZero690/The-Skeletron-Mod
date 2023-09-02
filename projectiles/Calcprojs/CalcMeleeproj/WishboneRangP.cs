using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.projectiles;

namespace TheSkeletronMod.projectiles.Calcprojs.CalcMeleeproj
{
    public class WishboneRangP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.aiStyle = 3;
            Projectile.width = 24;
           Projectile.height = 24;
            Projectile.friendly = true;
            Projectile.DamageType = ModContent.GetInstance<Bonecursed>();
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.NewProjectile(Projectile.GetSource_FromThis(),Projectile.position,new Vector2(Projectile.velocity.X * 2, Projectile.velocity.Y), ModContent.ProjectileType<WishboneRangPOne>(), 4, 2, Projectile.owner);

        }

    }
    public class WishboneRangPOne : ModProjectile
    {

    }
}
