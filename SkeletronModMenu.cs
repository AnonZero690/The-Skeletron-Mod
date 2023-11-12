using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheSkeletronMod.Common.Systems;
using ReLogic.Content;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;

namespace TheSkeletronMod
{
    public class SkeletronModMenu : ModMenu
    {
        private const string menuAssetPath = "TheSkeletronMod/Assets/Textures/Menu"; // Creates a constant variable representing the texture path, so we don't have to write it out multiple times

        public override Asset<Texture2D> Logo => ModContent.Request<Texture2D>($"{menuAssetPath}/bod_logo", (AssetRequestMode)2);

        public override Asset<Texture2D> SunTexture => ModContent.Request<Texture2D>($"{menuAssetPath}/SkullSun");

        public override Asset<Texture2D> MoonTexture => ModContent.Request<Texture2D>($"{menuAssetPath}/SkullMoon");

        public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/Assault");
        private float floatX;

        private float floatY;

        public override string DisplayName => "The Dungeon's Last Hurrah";

        public override void OnSelected()
        {
            SoundEngine.PlaySound(SkelSound.ModMenuClick);

        }

public override bool PreDrawLogo(SpriteBatch spriteBatch, ref Vector2 logoDrawCenter, ref float logoRotation, ref float logoScale, ref Color drawColor)
        {
            logoScale = 2f;
            Vector2 OffsetVector = Vector2.Zero;
            Texture2D backTexture = ModContent.Request<Texture2D>("TheSkeletronMod/Assets/Textures/Menu/BGPL").Value;
            Vector2 TextureSize = backTexture.Size();
            float WidthScalar = (float)Main.ScreenSize.X / (float)backTexture.Width;
            float HeightScalar = (float)Main.ScreenSize.Y / (float)backTexture.Height;
            float OverallScalar;
            if (WidthScalar > HeightScalar)
            {
                OverallScalar = WidthScalar;
                OffsetVector.Y -= ((float)backTexture.Height * OverallScalar - (float)Main.ScreenSize.Y) * 0.5f;
            }
            else
            {
                OverallScalar = HeightScalar;
                OffsetVector.X -= ((float)backTexture.Width * OverallScalar - (float)Main.ScreenSize.X) * 0.5f;
            }
            spriteBatch.Draw(backTexture, OffsetVector, null, Color.White, 0f, Vector2.Zero, OverallScalar, SpriteEffects.None, 0f);
            Main.dayTime = true;
            Main.time = 27000;
            return true;
        }
    }
}