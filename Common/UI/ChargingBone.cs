using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.GameContent;
using System.Collections.Generic;
using TheSkeletronMod.Modplayer;

namespace TheSkeletronMod.Common.UI
{
    internal class BBui : UIState
    {

        private UIElement area;
        private UIImage ImageLoc;

        public override void OnInitialize()
        {
            area = new UIElement();
            area.Left.Set(930, 0f);
            area.Top.Set(635, 0f);
            area.Width.Set(182, 0f);
            area.Height.Set(60, 0f);
            ImageLoc = new UIImage(ModContent.Request<Texture2D>("TheSkeletronMod/Common/UI/ChargingBone"));
            ImageLoc.Left.Set(-50, 0f);
            ImageLoc.Top.Set(-40, 0f);
            ImageLoc.Width.Set(138, 0f);
            ImageLoc.Height.Set(50, 0f);

            area.Append(ImageLoc);
            Append(area);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);
            float bar = (float)Main.LocalPlayer.GetModPlayer<SkullModplayer>().cc / Main.LocalPlayer.GetModPlayer<SkullModplayer>().ccMM;
            bar = Utils.Clamp(bar, 0f, 1f);

            Rectangle locbar = ImageLoc.GetInnerDimensions().ToRectangle();
            locbar.X += 12;
            locbar.Y += 8;
            locbar.Width -= 24;
            locbar.Height -= 16;

            int L = locbar.Left + 4;
            int R = locbar.Right + 22;
            int line = (int)((R - L) * bar);
            for (int i = 0; i < line; i += 1)
            {
                float prog = (float)i / (R - L);
                spriteBatch.Draw(TextureAssets.MagicPixel.Value, new Rectangle(L + i, locbar.Y, 1, locbar.Height), Color.Lerp(new Color(73, 66, 48), new Color(125, 116, 93), prog));
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

    }

    class BBu : ModSystem
    {
        static UserInterface ccI1;

        internal BBui cc1;



        public override void Load()
        {

            if (!Main.dedServ)
            {
                cc1 = new();
                ccI1 = new();
                ccI1.SetState(cc1);
            }
        }

        public override void UpdateUI(GameTime gameTime)
        {
            ccI1?.Update(gameTime);
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int resourceBarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Inventory"));
            if (resourceBarIndex != -1)
            {
                if (Main.LocalPlayer.GetModPlayer<SkullModplayer>().ShowChargeBar == true)
                {
                    ccI1.SetState(cc1);

                    layers.Insert(resourceBarIndex, new LegacyGameInterfaceLayer(
                        "TheSkeletronMod: Charging Bone Bar",
                        delegate
                        {
                            ccI1.Draw(Main.spriteBatch, new GameTime());
                            return true;
                        },
                        InterfaceScaleType.UI)
                        );
                }
                else
                {
                    if (Main.LocalPlayer.GetModPlayer<SkullModplayer>().ShowChargeBar == false)
                    {
                        ccI1.SetState(null);
                    }
                }
            }
        }
    }
}

