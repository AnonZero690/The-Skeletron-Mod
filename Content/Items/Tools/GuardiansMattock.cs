using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheSkeletronMod.Content.Items.Tools
{
    public class GuardiansMattock : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 50;
            Item.height = 40;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.pick = 100;
            Item.attackSpeedOnlyAffectsWeaponAnimation = true;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.damage = 20;
            Item.DamageType = DamageClass.Melee;
            Item.knockBack = 3;
            Item.value = Item.buyPrice(gold: 4);
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;

        }
    }
}
