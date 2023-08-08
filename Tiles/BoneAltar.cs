using Microsoft.Xna.Framework;

using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace TheSkeletronMod.Tiles
{
    public class BoneAltar : ModTile
    {
        public override void SetStaticDefaults()
        {

            Main.tileTable[Type] = true;
            Main.tileSolidTop[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileID.Sets.IgnoredByNpcStepUp[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.Width = 4;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16 };

            DustType = DustID.WoodFurniture;
            LocalizedText name = CreateMapEntryName();

            AddMapEntry(new Color(50, 30, 150), name);
            TileObjectData.addTile(Type);
        }


    }
}