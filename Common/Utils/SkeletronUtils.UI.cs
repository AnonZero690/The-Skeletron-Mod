using Microsoft.Xna.Framework;
using Terraria;
using Terraria.UI;

namespace TheSkeletronMod.Common.Utils
{
    public static partial class SkeletronUtils
    {
        public static void UISetWidthHeight(this UIElement ui, float width, float height)
        {
            ui.Width.Pixels = width;
            ui.Height.Pixels = height;
        }
        /// <summary>
        /// Set the position like you are doing PreDraw trail in projectile code
        /// </summary>
        /// <param name="ui"></param>
        /// <param name="position"></param>
        /// <param name="origin"></param>
        public static void UISetPosition(this UIElement ui, Vector2 position, Vector2 origin)
        {
            Vector2 drawpos = position - Main.screenPosition - origin;
            ui.Left.Pixels = drawpos.X + (drawpos.X * (1 - Main.UIScale));
            ui.Top.Pixels = drawpos.Y + (drawpos.X * (1 - Main.UIScale));
        }
    }
}
