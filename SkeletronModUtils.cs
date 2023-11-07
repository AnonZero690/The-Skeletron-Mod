using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheSkeletronMod
{
    public static class SkeletronModUtils
    {
        //from Lion8cake
        public static void Merge(int tile, int tile2)
        {
            Main.tileMerge[tile][tile2] = true;
            Main.tileMerge[tile2][tile] = true;
        }
    }
}