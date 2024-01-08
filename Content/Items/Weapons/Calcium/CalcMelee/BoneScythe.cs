using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.Common.Utils;
using TheSkeletronMod.Content.Projectiles.Calcprojs.CalcMeleeproj;
using TheSkeletronMod.Content.Items.Materials;
using TheSkeletronMod.Content.Items.Placeables;
using TheSkeletronMod.Content.Items.Placeables.Bars;
using TheSkeletronMod.Content.Items.Materials.OreBones;
using TheSkeletronMod.Content.Tiles;

namespace TheSkeletronMod.Content.Items.Weapons.Calcium.CalcMelee
{
    internal class BoneScythe : ModItem//, MeleeWeaponWithImprovedSwing
    {
        public float swingDegree => 150;
        public float Offset => 0f;

        public override void SetDefaults()
        {
            Item.ItemDefaultMeleeShootProjectile(54, 33, 30, 7f, 25, 25, ItemUseStyleID.Swing, ModContent.ProjectileType<BoneScytheP>(), 10, false);
            Item.DamageType = ModContent.GetInstance<Bonecursed>();
            Item.UseSound = SoundID.Item1;
        }
        public override bool MeleePrefix()
        {
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<CalciumBar>(), 10)
                .AddIngredient(ModContent.ItemType<DemoniteBone>(), 10)
                .AddIngredient(ItemID.Bone, 40)
                .AddTile(ModContent.TileType<BoneAltar>())
                .Register();
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<CalciumBar>(), 10)
                .AddIngredient(ModContent.ItemType<CrimtaneBone>(), 10)
                .AddIngredient(ItemID.Bone, 40)
                .AddTile(ModContent.TileType<BoneAltar>())
                .Register();
        }
    }
}
