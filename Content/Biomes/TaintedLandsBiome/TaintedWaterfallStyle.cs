using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TheSkeletronMod.Content.Biomes.TaintedLandsBiome
{
    public class TaintedWaterfallStyle : ModWaterfallStyle
    {
        public override void AddLight(int i, int j) =>
            Lighting.AddLight(new Vector2(i, j).ToWorldCoordinates(), Color.Purple.ToVector3() * 0.7f);
    }
}