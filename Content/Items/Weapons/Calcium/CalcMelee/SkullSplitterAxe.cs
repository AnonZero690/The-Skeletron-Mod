using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.Common.Utils;
using TheSkeletronMod.Content.Items.Materials;
using TheSkeletronMod.Content.Items.Materials.OreBones;
using TheSkeletronMod.Content.Projectiles.Calcprojs.CalcMeleeproj;

namespace TheSkeletronMod.Content.Items.Weapons.Calcium.CalcMelee
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
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<AncientBone>(), 10)
                .AddIngredient(ModContent.ItemType<CrimtaneBone>(), 10)
                .AddIngredient(ModContent.ItemType<PlatinumBone>(), 10)
                .AddIngredient(ModContent.ItemType<LeadBone>(), 10)
                .AddIngredient(ModContent.ItemType<WoodenBone>(), 10)
                .AddTile(TileID.Anvils)
                .Register();

        }
    }
}
