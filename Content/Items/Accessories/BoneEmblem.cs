using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheSkeletronMod.Content.Items.Accessories
{
    class BoneEmblem : ModItem
    {
        public override void SetDefaults() {
            Item.accessory = true;
            Item.width = 32;
            Item.height = 32;
            Item.rare = ItemRarityID.Green;
            Item.value = 5000;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage<Common.DamageClasses.Bonecursed>() += 0.15f;
        }
    }
}
