using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using TheSkeletronMod.Tiles.Blocks.Biomes.AccursedInfection;

namespace TheSkeletronMod.Items.Placeables.Biome.AccursedInfection.Blocks
{
    internal class Hexstone : ModItem
    {
        public override void SetDefaults()
        {

            Item.width = 22;
            Item.height = 18;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.consumable = true;
            Item.material = true;

            Item.maxStack = 9999;
            Item.rare = ItemRarityID.LightPurple;

            Item.createTile = ModContent.TileType<HexstoneT>();
        }
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
            ItemID.Sets.SortingPriorityMaterials[Item.type] = 58;
        }
    }
}
