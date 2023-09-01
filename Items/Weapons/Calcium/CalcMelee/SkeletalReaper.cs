using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.Common.Globals;
using TheSkeletronMod.projectiles.Calcprojs.CalcMeleeproj;

namespace TheSkeletronMod.Items.Weapons.Calcium.CalcMelee
{
    public class SkeletalReaper : ModItem, MeleeWeaponWithImprovedSwing
    {
        public float swingDegree => 170;
        public override void SetDefaults()
        {
            Item.ItemDefaultMeleeShootCustomProjectile(54, 33, 130, 7f, 25, 25, ItemUseStyleID.Swing, ModContent.ProjectileType<SkeletalReaperP>(), 10, true);
            Item.DamageType = ModContent.GetInstance<Bonecursed>();
            Item.UseSound = SoundID.Item1;
        }
        public override bool MeleePrefix()
        {
            return true;
        }
    }
}
