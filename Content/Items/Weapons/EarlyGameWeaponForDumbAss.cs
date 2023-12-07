using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.Globals;
using TheSkeletronMod.Common.Utils;

namespace TheSkeletronMod.Content.Items.Weapons
{
    internal class EarlyGameWeaponForDumbAss : ModItem
    {
        public override string Texture => SkeletronUtils.GetVanillaTexture<Item>(ItemID.BoneWand);
        public override void SetDefaults()
        {
            Item.width = Item.height = 36;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.damage = 13;
            Item.knockBack = 5.6f;
            Item.useTime = Item.useAnimation = 28;
            if (Item.TryGetGlobalItem(out ImprovedSwingSword meleeItem))
            {
                meleeItem.ArrayOfAttack = new CustomAttack[]
                {
                   new SlashAttack(),
                   new Slash2Attack()
                };
            }
        }
    }
}
