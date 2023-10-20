using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Tiles;

namespace TheSkeletronMod.Items.Materials.OreBones
{
    public class CopperBone : ModItem
    {
        public override void SetDefaults()
        {

            Item.width = 20;
            Item.height = 28;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(0, 0, 10, 0);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.CopperBar, 5);
            recipe.AddTile(ModContent.TileType<BoneAltar>());
            recipe.Register();
        }
    }
}