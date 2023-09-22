using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.projectiles.Calcprojs.CalcRangeProj;

namespace TheSkeletronMod.Items.Weapons.Calcium.CalcRange
{
    public class BoneLongbow : ModItem
    {
        public override void SetDefaults()
        {
            Item.ItemDefaultRange(56, 2, 64, 2f, 40, 40, ItemUseStyleID.Shoot, ProjectileID.BoneArrow, 120f, false, AmmoID.Arrow);
            Item.noMelee = true;
            Item.ArmorPenetration = 2;
            Item.DamageType = ModContent.GetInstance<Bonecursed>();
            Item.maxStack = 1;
            Item.crit = 15;
            Item.UseSound = SoundID.Item5;
            Item.value = 1000;
            Item.rare = ItemRarityID.Blue;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            Projectile.NewProjectile(source, position, velocity * new Vector2(2,1), type, damage, knockback, player.whoAmI, 0, 1);
            return true;
        }
    }
}
