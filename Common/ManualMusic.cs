using Terraria.ModLoader;

namespace SkellyModYT.Common
{

    public sealed class ManualMusic : ILoadable
    {
        public void Load(Mod mod)
        {
            MusicLoader.AddMusic(mod, "Assets/Music/Assault");


        }

        public void Unload()
        {

        }
    }
}
