using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.Globals;
using TheSkeletronMod.projectiles.Calcprojs.CalcMeleeproj;

namespace TheSkeletronMod.Items.Weapons.Calcium.CalcMelee
{
    public class BoneSword : ModItem, MeleeWeaponWithImprovedSwing
    {
        public float swingDegree => 360;
        public float Offset => 0;
        public override void SetDefaults()
        {
            Item.ItemDefaultMeleeCustomProjectile(12,12,17,0,10,10,ItemUseStyleID.Swing, ModContent.ProjectileType<BoneSwordP>(), false);
            Item.shootSpeed = 6f;
        }
        public override void SetStaticDefaults()
        {

            Main.itemFrameCounter[Item.type] = 8;
        }
    }
}
