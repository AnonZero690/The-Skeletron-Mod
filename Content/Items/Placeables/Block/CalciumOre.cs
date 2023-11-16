using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Content.Tiles.Blocks;

namespace TheSkeletronMod.Content.Items.Placeables.Block
{
    public class CalciumOre : ModItem
    {
        public override void SetDefaults()
        {

            Item.width = 32;
            Item.height = 16;

            Item.useTime = 15;
            Item.useAnimation = 15;

            Item.useStyle = ItemUseStyleID.Swing;

            Item.autoReuse = true;
            Item.useTurn = true;
            Item.consumable = true;
            Item.material = true;

            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Green;

            Item.createTile = ModContent.TileType<CalciumOreT>();
        }
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
            ItemID.Sets.SortingPriorityMaterials[Item.type] = 58;
        }
    }
}
