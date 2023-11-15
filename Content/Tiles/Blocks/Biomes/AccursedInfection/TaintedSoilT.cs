using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TheSkeletronMod.Content.Tiles.Blocks.Biomes.AccursedInfection
{
    public class TaintedSoilT : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            TheSkeletronMod.tileMerge[Type, Mod.Find<ModTile>("TaintedGrassT").Type] = true;
            TheSkeletronMod.tileMerge[Type, Mod.Find<ModTile>("TaintedSoilT").Type] = true;
            TheSkeletronMod.tileMerge[Type, Mod.Find<ModTile>("HexstoneT").Type] = true;
            RegisterItemDrop(ModContent.ItemType<Items.Placeables.Biome.AccursedInfection.Blocks.TaintedSoil>());

            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(136, 84, 131));
        }
    }
}
