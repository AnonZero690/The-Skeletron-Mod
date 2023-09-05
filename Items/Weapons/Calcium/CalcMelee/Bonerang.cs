using System;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.projectiles.Calcprojs.CalcMeleeproj;
namespace TheSkeletronMod.Items.Weapons.Calcium.CalcMelee
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
    }
}
