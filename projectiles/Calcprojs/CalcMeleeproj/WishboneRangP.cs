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
            Projectile.NewProjectile(Projectile.GetSource_FromThis(),Projectile.position,new Vector2(Projectile.velocity.X * -2, Projectile.velocity.Y), ModContent.ProjectileType<WishboneRangPOne>(), 7, 2, Projectile.owner);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, new Vector2(Projectile.velocity.X * -1.6f, Projectile.velocity.Y), ModContent.ProjectileType<WishboneRangPTwo>(), 9, 2, Projectile.owner);

        }

    }
    public class WishboneRangPOne : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.aiStyle = 3;
            Projectile.width = 24;
            Projectile.height = 24;
            Projectile.friendly = true;
            Projectile.scale = 1.2f;
            Projectile.penetrate = 2;
            Projectile.DamageType = ModContent.GetInstance<Bonecursed>();
            Projectile.aiStyle = 1;
        }
        //public override void AI()
        //{
        //    Projectile.velocity.Y = Projectile.velocity.Y + 0.1f; // 0.1f for arrow gravity, 0.4f for knife gravity
        //    if (Projectile.velocity.Y > 16f) // terminal velocity
        //    {
        //        Projectile.velocity.Y = 16f;
        //    }
        //}
    }
    public class WishboneRangPTwo : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.aiStyle = 3;
            Projectile.width = 24;
            Projectile.height = 24;
            Projectile.friendly = true;
            Projectile.scale = 1.2f;
            Projectile.penetrate = 3;
            Projectile.DamageType = ModContent.GetInstance<Bonecursed>();
            Projectile.aiStyle = 1;
        }
        //public override void AI()
        //{
        //    Projectile.velocity.Y = Projectile.velocity.Y + 0.3f; // 0.1f for arrow gravity, 0.4f for knife gravity
        //    if (Projectile.velocity.Y > 16f) // terminal velocity
        //    {
        //        Projectile.velocity.Y = 16f;
        //    }
        //}
    }
}
