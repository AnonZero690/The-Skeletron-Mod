using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.Common.Utils;
using TheSkeletronMod.Content.Projectiles.Calcprojs.CalcMeleeproj;

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
    }
}
