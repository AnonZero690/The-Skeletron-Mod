using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.Common.Utils;
using TheSkeletronMod.Content.Items.Materials.OreBones;
using TheSkeletronMod.Content.Items.Placeables.Block;
using TheSkeletronMod.Content.Projectiles.Calcprojs.CalcMeleeproj;

namespace TheSkeletronMod.Content.Items.Weapons.Calcium.CalcMelee
{
    class Bonerang : ModItem
    {
        public override void SetDefaults()
        {
            Item.ItemDefaultMeleeCustomProjectile(30, 24, 25, 1, 30, 30, ItemUseStyleID.Swing, ModContent.ProjectileType<BonerangProjectile>(), true);
            Item.DamageType = ModContent.GetInstance<Bonecursed>();
            Item.shootSpeed = 6f;
            Item.rare = 1;
            Item.value = 10000;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<StoneBone>(), 3)
            .AddIngredient(ModContent.ItemType<LeadBone>(), 3)
            .AddTile(TileID.Anvils)
            .Register();

             CreateRecipe()
            .AddIngredient(ModContent.ItemType<StoneBone>(), 3)
            .AddIngredient(ModContent.ItemType<IronBone>(), 3)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}
