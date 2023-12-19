using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.GameContent.UI.Elements;
using Terraria.GameContent;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria;
using TheSkeletronMod.Common.Systems;
using TheSkeletronMod.Content.Items.Weapons.Calcium.CalcRange;
using System.Security.Cryptography.X509Certificates;

//namespace TheSkeletronMod.Common.UI
//{
//    // This custom UI will show whenever the player is holding the ExampleCustomResourceWeapon item and will display the player's custom resource amounts that are tracked in ExampleResourcePlayer
//    internal class SoulResourceBar : UIState
//    {
//        // For this bar we'll be using a frame texture and then a gradient inside bar, as it's one of the more simpler approaches while still looking decent.
//        // Once this is all set up make sure to go and do the required stuff for most UI's in the ModSystem class.

//        //private UIText text;
//        private UIElement area;
//        private UIImage barFrame;
//        private Color gradientA;
//        private Color gradientB;
//        int frame = 0;
//        int framecount;

//        public override void OnInitialize()
//        {
//            // Create a UIElement for all the elements to sit on top of, this simplifies the numbers as nested elements can be positioned relative to the top left corner of this element. 
//            // UIElement is invisible and has no padding.
//            area = new UIElement();
//            area.Left.Set(-area.Width.Pixels - 600, 1f); // Place the resource bar to the left of the hearts.         //done
//            area.Top.Set(20, 0f); // Placing it just a bit below the top of the screen.                          //done
//            area.Width.Set(90, 0f); // We will be placing the following 2 UIElements within this 182x60 area.
//            area.Height.Set(60, 0f);

//            barFrame = new UIImage(ModContent.Request<Texture2D>("TheSkeletronMod/Common/UI/SoulResourceFrame"));


//            //barFrame = new UIAnimatedImage { Width = area.Width, Height = area.Height };
            
            // Frame of our resource bar
            barFrame.Left.Set(22, 0f);
            barFrame.Top.Set(0, 0f);       //height on the screen (both assests)
            barFrame.Width.Set(74, 0f);
            barFrame.Height.Set(38, 0f);    //height of resource bar

//            //text = new UIText("0/0", 0.8f); // text to show stat
//            //text.Width.Set(138, 0f);
//            //text.Height.Set(34, 0f);
//            //text.Top.Set(70, 0f);
//            //text.Left.Set(0, 0f);

//            gradientA = new Color(56, 255, 255); // A dark cyan
//            gradientB = new Color(206, 254, 255); // A light purple

//            //area.Append(text);
//            area.Append(barFrame);
//            Append(area);
//        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            const int X = 22;
            const int Y = 0;


            if (Main.LocalPlayer.HeldItem.ModItem is not MarrowMelter)
                return;

            base.Draw(spriteBatch);
        }



//        // Here we draw our UI
//        protected override void DrawSelf(SpriteBatch spriteBatch)
//        { 

            base.DrawSelf(spriteBatch);

//            var modPlayer = Main.LocalPlayer.GetModPlayer<SoulResourcePlayer>();
//            // Calculate quotient

//            float quotient = (float)modPlayer.SoulResourceCurrent / modPlayer.SoulResourceMax2; // Creating a quotient that represents the difference of your currentResource vs your maximumResource, resulting in a float of 0-1f.
//            quotient = MathHelper.Clamp(quotient, 0f, 1f); // Clamping it to 0-1f so it doesn't go over that.

//            // Here we get the screen dimensions of the barFrame element, then tweak the resulting rectangle to arrive at a rectangle within the barFrame texture that we will draw the gradient. These values were measured in a drawing program.
//            Rectangle hitbox = barFrame.GetInnerDimensions().ToRectangle();
//            hitbox.X += 18;
//            hitbox.Width -= 24;
//            hitbox.Y += 30;
//            hitbox.Height -= 16;

//            // Now, using this hitbox, we draw a gradient by drawing vertical lines while slowly interpolating between the 2 colors.
//            int left = hitbox.Left;
//            int right = hitbox.Right;
//            int steps = (int)((right - left) * quotient);
//            for (int i = 0; i < steps; i += 1)
//            {
//                // float percent = (float)i / steps; // Alternate Gradient Approach
//                float percent = (float)i / (right - left);
//                spriteBatch.Draw(TextureAssets.MagicPixel.Value, new Rectangle(left + i, hitbox.Y, 1, hitbox.Height), Color.Lerp(gradientA, gradientB, percent));
//            }
//        }

//        //public override void Update(GameTime gameTime)
//        //{
//            //if (Main.LocalPlayer.HeldItem.ModItem is not MarrowMelter)
//                //return;

//            //var modPlayer = Main.LocalPlayer.GetModPlayer<SoulResourcePlayer>();
//            // Setting the text per tick to update and show our resource values.
//            //text.SetText(SoulResourceUISystem.SoulResourceText.Format(modPlayer.SoulResourceCurrent, modPlayer.SoulResourceMax2));
//            //base.Update(gameTime);
//        //}
//    }

//    // This class will only be autoloaded/registered if we're not loading on a server
//    [Autoload(Side = ModSide.Client)]
//    internal class SoulResourceUISystem : ModSystem
//    {
//        private UserInterface SoulResourceBarUserInterface;

//        internal SoulResourceBar SoulResourceBar;

//        public static LocalizedText SoulResourceText { get; private set; }

//        public override void Load()
//        {
//            SoulResourceBar = new();
//            SoulResourceBarUserInterface = new();
//            SoulResourceBarUserInterface.SetState(SoulResourceBar);

//            string category = "UI";
//            SoulResourceText ??= Mod.GetLocalization($"{category}.SoulResource");
//        }

//        public override void UpdateUI(GameTime gameTime)
//        {
//            SoulResourceBarUserInterface?.Update(gameTime);
//        }

//        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
//        {
//            int resourceBarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Resource Bars"));
//            if (resourceBarIndex != -1)
//            {
//                layers.Insert(resourceBarIndex, new LegacyGameInterfaceLayer(
//                    "Soul Bar: Soul Resource Bar",
//                    delegate {
//                        SoulResourceBarUserInterface.Draw(Main.spriteBatch, new GameTime());
//                        return true;
//                    },
//                    InterfaceScaleType.UI)
//                );
//            }
//        }

//    }

//}
