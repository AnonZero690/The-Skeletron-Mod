using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.Items.Placeables.Block;
using TheSkeletronMod.Buffs;

namespace TheSkeletronMod.Items.Weapons.Calcium.CalcMelee
{
    class SkullSplitterAxe : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 22;
            Item.DamageType = ModContent.GetInstance<Bonecursed>();
            Item.useStyle = 1;
            Item.useAnimation = 20;
            Item.useTime = 12;
            Item.UseSound = SoundID.Critter;
            Item.axe = 50;
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            switch (Main.rand.Next(0,6))
            {
                case 0:
                    Item.NewItem(target.GetSource_FromThis(), target.getRect(), ItemID.Wood, Main.rand.Next(5,10));
                    break;
                case 1:
                    Item.NewItem(target.GetSource_FromThis(), target.getRect(), ModContent.ItemType<CalciumOre>(), Main.rand.Next(5, 10));
                    break;
                case 2:
                    target.AddBuff(ModContent.BuffType<BonedDebuff>(), 240);
                    break;
            }
        }
    }
}
