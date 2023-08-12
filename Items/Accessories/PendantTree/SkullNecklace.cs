using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Tiles;
using Microsoft.Xna.Framework;
using TheSkeletronMod.Items.Materials;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using TheSkeletronMod.Common.DamageClasses;

namespace TheSkeletronMod.Items.Accessories.PendantTree
{
    internal class SkullNecklace : ModItem
    {

        public override void SetDefaults()
        {
            Item.value = 12000;
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(ModContent.GetInstance<Bonecursed>()) += 0.05f;
            player.endurance += 0.05f;
            Lighting.AddLight(player.position, r: 0.6f, 0.3f, b: 1f);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<SkullPendant>(), 1);
            recipe.AddIngredient(ModContent.ItemType<AncientBone>(), 25);
            recipe.AddIngredient(ItemID.Cobweb, 10);
            recipe.AddTile(ModContent.TileType<BoneAltar>());
            recipe.Register();
        }

    }
}