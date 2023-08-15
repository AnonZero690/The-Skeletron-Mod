using Microsoft.Xna.Framework;
using TheSkeletronMod.Items.Materials;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using TheSkeletronMod.Common.DamageClasses;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using TheSkeletronMod.Tiles;

namespace TheSkeletronMod.Items.Accessories.PendantTree
{
    public class SkullLocket : ModItem
    {

        public override void SetDefaults()
        {
            Item.height = 17;
            Item.width = 18;
            Item.value = 17000;
            Item.rare = ItemRarityID.Orange;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(ModContent.GetInstance<Bonecursed>()) += 0.10f;
            player.endurance += 0.05f;
            Lighting.AddLight(player.position, r: 0.6f, 0.3f, b: 1f);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<SkullNecklace>(), 1);
            recipe.AddIngredient(ModContent.ItemType<AncientBone>(), 50);
            recipe.AddIngredient(ItemID.BookofSkulls, 1);
            recipe.AddTile(ModContent.TileType<BoneAltar>());
            recipe.Register();
        }

    }
}
