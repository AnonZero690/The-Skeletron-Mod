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