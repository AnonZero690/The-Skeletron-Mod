using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;

namespace TheSkeletronMod.projectiles.Calcprojs.CalcMeleeproj
{
    class BonerangProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.damage = 25;
            Projectile.DamageType = ModContent.GetInstance<Bonecursed>();
            Projectile.penetrate = -1;
            Projectile.friendly = true;
        }
        public override void OnSpawn(IEntitySource source)
        {
            Projectile.ai[0] = 90;
            Vector2 vectormove = Main.MouseWorld - Main.player[Projectile.owner].position;
            vectormove.Normalize();
            Projectile.ai[1] = vectormove.X;
            Projectile.ai[2] = vectormove.Y;
            Projectile.velocity = new Vector2(Projectile.ai[1], Projectile.ai[2]) * 9f;
        }
        private void ReturnFunction(Vector2 v)
        {
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, -v.RotatedBy(Math.PI / 10), ModContent.ProjectileType<BonerangReturnProjectile>(), 15, 4f, Projectile.owner);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, -v.RotatedBy(-Math.PI / 10), ModContent.ProjectileType<BonerangReturnProjectile>(), 15, 4f, Projectile.owner);
            Projectile.Kill();
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            ReturnFunction(oldVelocity);
            return false;
        }
        public override void AI()
        {
            Projectile.ai[0]--;
            Projectile.rotation += 0.17f;
            if (Projectile.ai[0] < 1)
            {
                ReturnFunction(Projectile.velocity);
            }
        }
    }
}