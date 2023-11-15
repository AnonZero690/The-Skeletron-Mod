using Terraria.ModLoader;
using Terraria;
using System;
using Terraria.Audio;
using TheSkeletronMod.Common.Utils;

namespace TheSkeletronMod
{
	public class TheSkeletronMod : Mod
	{

        public static TheSkeletronMod Instance = new();

        public const string AssetPath = $"{nameof(TheSkeletronMod)}/Assets/";

        //From here
        private static TileTest v = new();
        public static TileTest tileMerge => v;

        public class TileTest
        {
            public bool this[int tile1, int tile2]
            {
                get => Main.tileMerge[tile1][tile2] || Main.tileMerge[tile2][tile1];
                set => SkeletronUtils.Merge(tile1, tile2);
            }
        }
    }
}