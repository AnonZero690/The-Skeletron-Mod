using System;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.projectiles.Calcprojs.CalcMeleeproj;
namespace TheSkeletronMod.Items.Weapons.Calcium.CalcMelee
{
    class Bonerang : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 24;
            Item.damage = 25;
            Item.useStyle = 1;
            Item.rare = 1;
            Item.value = 10000;
            Item.DamageType = ModContent.GetInstance<Bonecursed>();
            Item.shoot = ModContent.ProjectileType<BonerangProjectile>();
            Item.noMelee = true;
            Item.shootSpeed = 4f;
            Item.noUseGraphic = true;
            Item.useTime = 30;
            Item.useAnimation = 30;
        }
    }
}
