﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TheSkeletronMod.Tiles.Blocks
{
    internal class CalciumOreT : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileID.Sets.Ore[Type] = true;

            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileShine[Type] = 950;
            Main.tileShine2[Type] = true;
            Main.tileLighted[Type] = true;

            Main.tileSpelunker[Type] = true;
            Main.tileOreFinderPriority[Type] = 350;

            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(218, 219, 221), name);

            DustType = DustID.Gold;


            MineResist = 1.5f;
            MinPick = 60;
        }
    }
}