using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheSkeletronMod
{
    public static partial class SkeletronUtils
    {
        /// <summary>
        /// Set your own DamageClass type
        /// </summary>
        public static void ItemSetDefault(this Item item, int width, int height, int damage, float knockback, int useTime, int useAnimation, int useStyle, bool autoReuse)
        {
            item.width = width;
            item.height = height;
            item.damage = damage;
            item.knockBack = knockback;
            item.useTime = useTime;
            item.useAnimation = useAnimation;
            item.useStyle = useStyle;
            item.autoReuse = autoReuse;
        }
        public static void ItemDefaultToConsume(this Item item, int width, int height)
        {
            item.width = width;
            item.height = height;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = ItemUseStyleID.HoldUp;
            item.autoReuse = false;
            item.consumable = true;
        }
        /// <summary>
        /// Use this along with <see cref="ItemSetDefault(Item, int, int, int, float, int, int, int, bool)"/>
        /// </summary>
        /// <param name="item"></param>
        /// <param name="spearType"></param>
        /// <param name="shootSpeed"></param>
        public static void ItemSetDefaultSpear(this Item item, int spearType, float shootSpeed)
        {
            item.noUseGraphic = true;
            item.noMelee = true;
            item.shootSpeed = shootSpeed;
            item.shoot = spearType;
        }
        /// <summary>
        /// Use this if you are making a sword that shoot out projectile
        /// </summary>
        /// <param name="item"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="damage"></param>
        /// <param name="knockback"></param>
        /// <param name="useTime"></param>
        /// <param name="useAnimation"></param>
        /// <param name="useStyle"></param>
        /// <param name="shoot"></param>
        /// <param name="shootspeed"></param>
        /// <param name="autoReuse"></param>
        public static void ItemDefaultMeleeShootProjectile(this Item item, int width, int height, int damage, float knockback, int useTime, int useAnimation, int useStyle, int shoot, float shootspeed, bool autoReuse)
        {
            ItemSetDefault(item, width, height, damage, knockback, useTime, useAnimation, useStyle, autoReuse);
            item.shoot = shoot;
            item.shootSpeed = shootspeed;
        }
        /// <summary>
        /// Use this if you are making a custom melee projectile like a spear or boomerang
        /// </summary>
        /// <param name="item"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="damage"></param>
        /// <param name="knockback"></param>
        /// <param name="useTime"></param>
        /// <param name="useAnimation"></param>
        /// <param name="useStyle"></param>
        /// <param name="shoot"></param>
        /// <param name="autoReuse"></param>
        public static void ItemDefaultMeleeCustomProjectile(this Item item, int width, int height, int damage, float knockback, int useTime, int useAnimation, int useStyle, int shoot, bool autoReuse)
        {
            ItemSetDefault(item, width, height, damage, knockback, useTime, useAnimation, useStyle, autoReuse);
            item.shoot = shoot;
            item.shootSpeed = 1;
            item.noMelee = true;
            item.noUseGraphic = true;
        }
        public static void ItemDefaultRange(this Item item, int width, int height, int damage, float knockback, int useTime, int useAnimation, int useStyle, int shoot, float shootSpeed, bool autoReuse, int useAmmo = 0
        )
        {
            ItemSetDefault(item, width, height, damage, knockback, useTime, useAnimation, useStyle, autoReuse);
            item.shoot = shoot;
            item.shootSpeed = shootSpeed;
            item.useAmmo = useAmmo;
            item.noMelee = true;
        }

        public static void ItemDefaultMagic(this Item item, int width, int height, int damage, float knockback, int useTime, int useAnimation, int useStyle, int shoot, float shootSpeed, int manaCost, bool autoReuse
            )
        {
            ItemSetDefault(item, width, height, damage, knockback, useTime, useAnimation, useStyle, autoReuse);
            item.shoot = shoot;
            item.shootSpeed = shootSpeed;
            item.mana = manaCost;
            item.noMelee = true;
        }
    }
}