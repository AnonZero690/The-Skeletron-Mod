using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Tiles.Blocks;
using TheSkeletronMod.Tiles.Blocks.Biomes.AccursedInfection;

namespace TheSkeletronMod.Items.Placeables.Biome.AccursedInfection.Blocks
{
    public class TaintedSoil : ModItem
    {
        public override void SetDefaults()
        {

            Item.width = 16;
            Item.height = 16;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.consumable = true;
            Item.material = true;

            Item.maxStack = 9999;
            Item.rare = ItemRarityID.LightPurple;

            Item.createTile = ModContent.TileType<TaintedSoilT>();
        }
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
            ItemID.Sets.SortingPriorityMaterials[Item.type] = 58;
        }
    }
}
