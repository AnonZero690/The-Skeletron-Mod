﻿using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TheSkeletronMod.Common.DamageClasses;
using Terraria.DataStructures;

namespace TheSkeletronMod.projectiles.Calcprojs.CalcMeleeproj
{
    class BonerangReturnProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.friendly = true;
            Projectile.damage = 15;
            Projectile.DamageType = ModContent.GetInstance<Bonecursed>();
            Projectile.penetrate = -1;
        }
        public override void AI()
        {
            Vector2 target = Main.player[Projectile.owner].position;
            if (Vector2.Distance(Projectile.position, target) < 64f) Projectile.Kill();
            else
            {
                target = Vector2.Normalize(Projectile.position - target);
                Projectile.position += target * 6f;
            }
        }
    }
}
