using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheSkeletronMod.Content.Items.Accessories.PendantTree
{
    [AutoloadEquip(EquipType.Neck)]
    public class CranialPendant : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 15;
            Item.value = 12000;
            Item.rare = ItemRarityID.Gray;
            Item.material = true;
            Item.accessory = true;
            Item.defense = 2;
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        { 
            Lighting.AddLight(player.position, r: 0.6f, 0.3f, b: 1f);
        }
        // Not supposed to be craftable
    }
}