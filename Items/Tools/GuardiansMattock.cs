using Terraria;
using Terraria.ModLoader;
using TheSkeletronMod.Tiles;

namespace TheSkeletronMod.Items.Tools
{
    public class GuardiansMattock : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.pick = 100;
            Item.useAnimation = 15;
            Item.useTime = 15;
        }
    }
}
