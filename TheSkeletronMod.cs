using Terraria.ModLoader;
using Terraria;
using System;
using Terraria.Audio;

namespace TheSkeletronMod
{
	public class TheSkeletronMod : Mod
	{

        public static TheSkeletronMod Instance = new();

        public const string AssetPath = $"{nameof(TheSkeletronMod)}/Assets/";

        public static float ModTime { get; internal set; }
        public static object MessageType { get; internal set; }

        public static int[] confectBG = new int[3];

        internal float screenOff;

        //From here
        private static TileTest v = new();
        public static TileTest tileMerge => v;

        public class TileTest
        {
            public bool this[int tile1, int tile2]
            {
                get => Main.tileMerge[tile1][tile2] || Main.tileMerge[tile2][tile1];
                set => SkeletronModUtils.Merge(tile1, tile2);
            }
        }
        //To here, is stuff Lion8cake allowed me to copy from confection so big hand to him
        internal static object GetLegacySoundSlot(object custom, string v)
        {
            throw new NotImplementedException();
        }

        internal static object GetLegacySoundSlot(SoundType soundType)
        {
            throw new NotImplementedException();
        }

       
    }
}