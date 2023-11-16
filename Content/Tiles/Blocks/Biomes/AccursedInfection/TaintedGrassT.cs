using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TheSkeletronMod.Content.Tiles.Blocks.Biomes.AccursedInfection
{
    public class TaintedGrassT : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileMergeDirt[Type] = true;
            TheSkeletronMod.tileMerge[Type, Mod.Find<ModTile>("TaintedSoilT").Type] = true;
            TheSkeletronMod.tileMerge[Type, Mod.Find<ModTile>("HexstoneT").Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileBlendAll[Type] = true;
            Main.tileSolid[Type] = true; 
            Main.tileBrick[Type] = true;
            Main.tileBlockLight[Type] = true;
            TileID.Sets.Grass[Type] = true;
            TileID.Sets.ChecksForMerge[Type] = true;
            TileID.Sets.ForcedDirtMerging[Type] = true;
            TileID.Sets.Conversion.MergesWithDirtInASpecialWay[Type] = true;
            TileID.Sets.Conversion.Grass[Type] = true;
            RegisterItemDrop(ModContent.ItemType<Items.Placeables.Biome.AccursedInfection.Blocks.TaintedSoil>());

            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(155, 127, 111));
        }
    }
}
