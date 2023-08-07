using Terraria.ID;
using Terraria.ModLoader;

namespace TheSkeletronMod.Items.Materials
{
    public class AncientBone : ModItem
    {
        public override void SetDefaults()
        {

            Item.width = 32;
            Item.height = 32;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Green;
        }
    }
}
