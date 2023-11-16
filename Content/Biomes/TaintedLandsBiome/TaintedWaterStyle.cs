using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ModLoader;
using TheSkeletronMod.Content.Dusts;

namespace TheSkeletronMod.Content.Biomes.TaintedLandsBiome
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
            return ModContent.Find<ModGore>("TheSkeletronMod/Assets/Gores/SplashGores").Type;
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