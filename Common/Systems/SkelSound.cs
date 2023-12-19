using Terraria.Audio;
using Terraria.ModLoader;

namespace TheSkeletronMod.Common.Systems
{

    public class SkelSound : ModSystem
    {
        ///<summary>
        /// Zero, when you're copying over the SoundSystem please do not add the static readonly fields before throwing a new exception, thats why it wasnt working.
        /// Just to clear that up! 👀👍
        /// Also .ogg files are much better (they have better quality and you can set whatever file size you want
        /// </summary>
        public static readonly SoundStyle MenuClickCrunch;

        public static readonly SoundStyle BoneCrunchShot;

        public static readonly SoundStyle DetectiveDeath;


        //Had to change it to a static not a private static.
        static SkelSound()
        {
            MenuClickCrunch = new SoundStyle("TheSkeletronMod/Assets/Sounds/MenuClickCrunch", (SoundType)0);
            BoneCrunchShot = new SoundStyle("TheSkeletronMod/Assets/Sounds/BoneCrunchShot", (SoundType)0);
            DetectiveDeath = new SoundStyle("TheSkeletronMod/Assets/Sounds/DetectiveDeath", (SoundType)0);
        }
    }
}