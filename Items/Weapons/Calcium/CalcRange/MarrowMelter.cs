using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using TheSkeletronMod.Tiles;
using Terraria.GameContent.Creative;
using TheSkeletronMod.Common.Systems;
using TheSkeletronMod.Items.Placeables.Bars;

namespace TheSkeletronMod.Items.Weapons.Calcium.CalcRange
{
    internal class MarrowMelter : ModItem
    {
        private int SoulResourceCost; // Add our custom resource cost

        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 10;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 80;
            Item.height = 28;
            Item.knockBack = 2f;
            Item.value = Item.buyPrice(gold: 15);
            Item.rare = ItemRarityID.Cyan;
            Item.shoot = ProjectileID.Flames;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shootSpeed = 10;
            Item.crit = 15;
            SoulResourceCost = 2;
            Item.useTime = 1;
            Item.useAnimation = 1;
            Item.autoReuse = true;
        }// Set our custom resource cost to 5


        //public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        //{
            //target.AddBuff(BuffID.OnFire, 5 * 60);
        //}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Flamethrower, 1);
            recipe.AddIngredient(ModContent.ItemType<SoulFlameBar>(), 15);
            //recipe.AddCondition(conditions: Condition.InGraveyard);
            recipe.Register();
        }


        // Make sure you can't use the item if you don't have enough resource
        public override bool CanUseItem(Player player)
        {
            var SoulResourcePlayer = player.GetModPlayer<SoulResourcePlayer>();

            return SoulResourcePlayer.SoulResourceCurrent >= SoulResourceCost;
        }

        // Reduce resource on use
        public override bool? UseItem(Player player)
        {
            var SoulResourcePlayer = player.GetModPlayer<SoulResourcePlayer>();

            SoulResourcePlayer.SoulResourceCurrent -= SoulResourceCost;

            return true;

        }
    }
}
