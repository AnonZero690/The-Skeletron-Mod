using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Content.Tiles;

namespace TheSkeletronMod.Content.Items.Materials.OreBones
{
    public class LeadBone : ModItem
    {
        public override void SetDefaults()
        {

            Item.width = 20;
            Item.height = 28;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(0, 0, 40, 0);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.LeadBar, 5);
            recipe.AddTile(ModContent.TileType<BoneAltar>());
            recipe.Register();
        }
    }
}