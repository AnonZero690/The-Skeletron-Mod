using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;

namespace TheSkeletronMod.Items.Weapons.Calcium.CalcRange
{
    class SkeletonBlunderBlaster : ModItem
    {
        public override void SetDefaults()
        {
            Item.noMelee = true;
            Item.useAmmo = AmmoID.Bullet;
            Item.damage = 12;
            Item.width = 32;
            Item.height = 32;
            Item.crit = 10;
            Item.DefaultToRangedWeapon(ProjectileID.Bullet, AmmoID.Bullet, 30, 6f, true);
            Item.DamageType = ModContent.GetInstance<Bonecursed>();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int numPellets = Main.rand.Next(5, 8);
            for (int i = 0; i < numPellets; i++)
            {
                float offset = Main.rand.NextFloat(-0.3f, 0.3f);

                Projectile.NewProjectile(source, position, velocity.RotatedBy(offset), type, damage, knockback);
            }
            return true;
        }
    }
}
