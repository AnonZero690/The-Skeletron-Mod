using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.projectiles.Calcprojs.CalcMeleeproj;

namespace TheSkeletronMod.Items.Weapons.Calcium.CalcMelee
{
    class SkullSplitterAxe : ModItem
    {
        public override void SetDefaults()
        {
            Item.ItemDefaultMeleeCustomProjectile(52, 54, 22, 3f, 20, 20, ItemUseStyleID.Shoot, ModContent.ProjectileType<SkullsplitterAxeProjectile>(), true);

            Item.DamageType = ModContent.GetInstance<Bonecursed>();
            Item.axe = 50;
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[ModContent.ProjectileType<SkullsplitterAxeProjectile>()] < 1;
        }
    }
}
