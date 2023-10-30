using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace TheSkeletronMod.Tiles.Blocks.Biomes.AccursedInfection
{
    public class HexstoneT : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[ModContent.TileType<AccursedSoilT>()] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;

            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(22, 22, 25));
        }
    }
}
