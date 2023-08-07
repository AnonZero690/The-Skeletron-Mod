using Terraria.ModLoader;

namespace RealmOne.Common
{

    public sealed class LoadingMusic : ILoadable
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
