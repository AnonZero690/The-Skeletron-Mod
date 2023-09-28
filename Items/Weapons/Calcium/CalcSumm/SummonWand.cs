using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using TheSkeletronMod;
using TheSkeletronMod.projectiles.Calcprojs.CalcSummProj;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;


namespace TheSkeletronMod.Items.Weapons.Calcium.CalcSumm
{
    public class SummonWand : ModItem
    {
        public override string Texture => SkeletronUtils.GetVanillaTexture<Item>(ItemID.BoneWand);
        public override void SetDefaults()
        {
            Item.damage = 20;       // Base damage of the weapon
            Item.knockBack = 2f;    // Knockback value
            Item.useStyle = 5;      // Use style (1 for swinging, 5 for summoning)
            Item.useAnimation = 25; // Duration of the animation
            Item.useTime = 25;      // Duration of the item use
            Item.rare = ItemRarityID.Orange;          // Rarity (0-11)
            Item.value = Item.buyPrice(gold: 2); // Value in copper coins
            Item.autoReuse = true;  // Automatically reuse the item
            Item.shoot = ModContent.ProjectileType<FloatingBone>(); // Specify the projectile that the weapon will summon
            Item.shootSpeed = 10f;  // Projectile speed
            Item.buffType = ModContent.BuffType<FloatingBoneMinionBuff>();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            // This is needed so the buff that keeps your minion alive and allows you to despawn it properly applies
            player.AddBuff(Item.buffType, 2);

            // Minions have to be spawned manually, then have originalDamage assigned to the damage of the summon item
            var projectile = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, Main.myPlayer);
            projectile.originalDamage = Item.damage;

            // Since we spawned the projectile manually already, we do not need the game to spawn it for ourselves anymore, so return false
            return false;
        }
    }
}
