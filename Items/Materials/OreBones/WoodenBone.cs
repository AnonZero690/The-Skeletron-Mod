using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Tiles;

namespace TheSkeletronMod.Items.Materials.OreBones
{
    public class WoodenBone : ModItem
    {
        public override void SetDefaults()
        {

            Item.width = 22;
            Item.height = 28;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(0, 0, 0, 2);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Wood, 50);
            recipe.AddTile(ModContent.TileType<BoneAltar>());
            recipe.Register();
        }
    }
}