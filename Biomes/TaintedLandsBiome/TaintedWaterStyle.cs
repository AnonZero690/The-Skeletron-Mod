using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using TheSkeletronMod.Dusts;
using Terraria.ModLoader;
using SteelSeries.GameSense;

namespace TheSkeletronMod.Biomes.TaintedLandsBiome
{
    public class TaintedWaterStyle : ModWaterStyle
    {
        public override int ChooseWaterfallStyle()
        {
            return ModContent.GetInstance<TaintedWaterfallStyle>().Slot;
        }

        public override int GetSplashDust()
        {
            return ModContent.DustType<TaintedSplash>();
        }

        public override int GetDropletGore()
        {
            return ModContent.Find<ModGore>("TheSkeletronMod/Gores/SplashGores").Type;
        }
        

        public override void LightColorMultiplier(ref float r, ref float g, ref float b)
        {
            r = 1f;
            g = 1f;
            b = 1f;
        }


        public override Color BiomeHairColor()
        {
            return Color.Purple;
        }

        public override byte GetRainVariant()
        {
            return (byte)Main.rand.Next(3);
        }

        public override Asset<Texture2D> GetRainTexture()
        {
            return ModContent.Request<Texture2D>("TheSkeletronMod/Biomes/TaintedLandsBiome/TaintedRain");
        }
    }
}