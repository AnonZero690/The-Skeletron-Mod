using Terraria.ModLoader;

namespace TheSkeletronMod.Common
{

    public sealed class ManualMusic : ILoadable
    {
        public void Load(Mod mod)
        {
            MusicLoader.AddMusic(mod, "TheSkeletronMod/Assets/Music/Assault");


        }

        public void Unload()
        {

        }
    }
}
