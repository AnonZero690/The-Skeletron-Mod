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

        public override Asset<Texture2D> Logo => ModContent.Request<Texture2D>($"{menuAssetPath}/Logopl", (AssetRequestMode)2);

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

            logoScale = 0.6f;
            Texture2D MenuBG = (Texture2D)ModContent.Request<Texture2D>("TheSkeletronMod/Assets/Textures/Menu/BGPL", (AssetRequestMode)2);
            Vector2 zero = Vector2.Zero;
            float width = Main.screenWidth / (float)MenuBG.Width;
            _ = Main.screenHeight / (float)MenuBG.Height;
            spriteBatch.Draw(MenuBG, new Vector2(zero.X + MathHelper.Lerp(-98f, -82f, floatX), zero.Y + MathHelper.Lerp(-50f, -47f, floatY)), null, Color.White, 0f, Vector2.Zero, width * 1.1f, 0, 0f);
            return true;
        }
    }
}