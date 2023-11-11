using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Tiles.Blocks;
using TheSkeletronMod.Items.Placeables.Block;

namespace TheSkeletronMod.Items.Placeables.Bars
{
    public class CalciumBar : ModItem
    {
        public override void SetDefaults()
        {


            Item.width = 15;
            Item.height = 12;

            Item.useTime = 15;
            Item.useAnimation = 15;

            Item.useStyle = ItemUseStyleID.Swing;

            Item.autoReuse = true;
            Item.useTurn = true;
            Item.consumable = true;
            Item.material = true;

            Item.maxStack = 9999;

            Item.createTile = ModContent.TileType<CalciumBarT>();
            Item.rare = ItemRarityID.Orange;
        }
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
            ItemID.Sets.SortingPriorityMaterials[Item.type] = 58;
        }
        public override void AddRecipes()       
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<CalciumOre>(), 3);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();
        }
    }
}