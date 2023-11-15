using Terraria;
using Terraria.ID;

namespace TheSkeletronMod.Common.Utils
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
    }
}