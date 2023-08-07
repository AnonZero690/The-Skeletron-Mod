using Terraria.Audio;
using Terraria.ModLoader;

namespace SkellyModYT.Common.Systems;

public class SkelSound : ModSystem
{
    public static readonly SoundStyle ModMenuClick;

    static SkelSound()
    {
        ModMenuClick = new SoundStyle("SkellyModYT/Assets/Sounds/ModMenuClick", (SoundType)0);
    }
}