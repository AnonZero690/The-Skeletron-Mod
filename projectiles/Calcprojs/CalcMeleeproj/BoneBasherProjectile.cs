using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria;
using TheSkeletronMod.Common.DamageClasses;
using Terraria.ID;
//using System.Numerics;
using Microsoft.Xna.Framework;
using Microsoft.CodeAnalysis;

namespace TheSkeletronMod.projectiles.Calcprojs.CalcMeleeproj
{
    internal class BoneBasherProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 64;
            //Projectile.gfxOffY = (float)-100.2;
        }
       public override void AI()
       {
           Player player = Main.LocalPlayer;
           Vector2 offset = new Vector2(-35,1);
            if (Main.mouseX > 800)
            {
                offset.X += 28;
            }else
            {
                //offset.X += -28;
            }
           //float shootToX = Main.mouseX - Projectile.Center.X;
           //float shootToY = Main.mouseY - Projectile.Center.Y;
           offset.Y += (Main.mouseY - 300) / 10;
           Vector2 d = (Main.MouseWorld - player.position).SafeNormalize(Vector2.UnitX).SafeNormalize(Vector2.UnitY);
           Projectile.position = new(player.position.X + offset.X, player.position.Y + offset.Y);
           Projectile.rotation = d.ToRotation() + MathHelper.ToRadians(23);
       }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.HealEffect(damageDone * -1);
        }
    }
}
