using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.projectiles.Calcprojs.CalcMeleeproj;

namespace TheSkeletronMod.Items.Weapons.Calcium.CalcMelee
{
    public class BoneScythe : ModItem
    {
        public override void SetDefaults()
        {
            Item.ItemDefaultMeleeShootCustomProjectile(54, 33, 50, 7f, 25, 25, ItemUseStyleID.Swing, ModContent.ProjectileType<BoneScytheP>(), 10, true);
            Item.DamageType = ModContent.GetInstance<Bonecursed>();
        }
    }
}
