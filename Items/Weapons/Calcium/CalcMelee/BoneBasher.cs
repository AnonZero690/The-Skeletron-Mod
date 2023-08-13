using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.Enums;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
using Terraria.ID;

namespace TheSkeletronMod.Items.Weapons.Calcium.CalcMelee
{
    internal class BoneBasher : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 70;
            Item.crit = 40;
            Item.DamageType = ModContent.GetInstance<Bonecursed>();
            Item.knockBack = 10;
            Item.rare = ItemRarityID.Green;
            Item.useAnimation = 70;
            Item.useTime = 70;
            Item.useStyle = ItemUseStyleID.Swing;

        }
    }
}
