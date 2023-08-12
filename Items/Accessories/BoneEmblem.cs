using System;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheSkeletronMod.Items.Accessories
{
    // not craftable, drops from WoF
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
