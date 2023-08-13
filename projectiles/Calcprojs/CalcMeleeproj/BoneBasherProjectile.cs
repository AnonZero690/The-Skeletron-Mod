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
            Projectile.gfxOffY = -12;
        }
       public override void AI()
       {
           Player player = Main.LocalPlayer;
           Vector2 offset = new Vector2(-10,0);
           float shootToX = Main.mouseX - Projectile.Center.X;
           float shootToY = Main.mouseY - Projectile.Center.Y;
           Vector2 d = (Main.MouseWorld - player.position).SafeNormalize(Vector2.UnitX);
            //Projectile.position = new(player.position.X + offset.X, player.position.Y + offset.Y);
           Projectile.rotation = d.ToRotation() + MathHelper.ToRadians(23);
       }
    }
}
