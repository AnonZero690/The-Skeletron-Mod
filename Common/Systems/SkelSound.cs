using Terraria.Audio;
using Terraria.ModLoader;

namespace TheSkeletronMod.Common.Systems;

public class SkelSound : ModSystem
{
    public static readonly SoundStyle ModMenuClick;

    static SkelSound()
    {
        ModMenuClick = new SoundStyle("TheSkeletronMod/Assets/Sounds/ModMenuClick", (SoundType)0);
    }
}