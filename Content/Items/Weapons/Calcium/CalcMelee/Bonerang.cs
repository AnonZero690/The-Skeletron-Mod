using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.Common.Utils;
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
    }
}
