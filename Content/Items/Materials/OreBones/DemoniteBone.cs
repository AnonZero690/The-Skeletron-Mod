using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Content.Tiles;

namespace TheSkeletronMod.Content.Items.Materials.OreBones
{
    public class DemoniteBone : ModItem
    {
        public override void SetDefaults()
        {

            Item.width = 20;
            Item.height = 28;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.sellPrice(0, 1, 42, 0);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DemoniteBar, 5);
            recipe.AddIngredient(ItemID.ShadowScale, 2);
            recipe.AddTile(ModContent.TileType<BoneAltar>());
            recipe.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ModContent.ItemType<CrimtaneBone>(), 1);
            recipe2.AddTile(ModContent.TileType<BoneAltar>());
            recipe2.Register();
        }
    }
}