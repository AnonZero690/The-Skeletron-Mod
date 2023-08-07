using Terraria.ID;
using Terraria.ModLoader;

namespace SkellyModYT.Items.Materials
{
    public class AncientBone : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.value = 0;
            Item.rare = ItemRarityID.Gray;
        }
    }
}