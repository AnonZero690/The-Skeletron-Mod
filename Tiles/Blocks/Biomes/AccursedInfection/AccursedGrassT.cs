using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria;

namespace TheSkeletronMod.Tiles.Blocks.Biomes.AccursedInfection
{
    public class AccursedGrassT : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[ModContent.TileType<AccursedSoilT>()] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;

            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(155, 127, 111));
        }
    }
}
