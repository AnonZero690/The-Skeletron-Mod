using Terraria;

namespace TheSkeletronMod.Common.Utils;

public partial class SkeletronUtils
{
    public static void Merge(int tile, int tile2)
    {
        Main.tileMerge[tile][tile2] = true;
        Main.tileMerge[tile2][tile] = true;
    }
}