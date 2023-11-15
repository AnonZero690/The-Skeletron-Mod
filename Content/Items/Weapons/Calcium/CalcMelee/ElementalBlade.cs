using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.Common.Globals;
using TheSkeletronMod.Content.Buffs;

namespace TheSkeletronMod.Content.Items.Weapons.Calcium.CalcMelee
{
    public class ElementalBlade : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.width = 60;
            Item.height = 60;
            Item.crit = 10;
            Item.DamageType = ModContent.GetInstance<Bonecursed>();
            if (Item.TryGetGlobalItem(out ImprovedSwingSword meleeItem))
            {
                meleeItem.ArrayOfAttack =
                    new CustomAttack[]
                    {
                        new CustomAttack(CustomUseStyle.CircleAttack, true)
                    };
            }
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            int timeToDebuff = 100;
            if (hit.Crit)
                timeToDebuff += 50;
            for (int i = 0; i < 2; i++)
            {
                int buffToAdd = 
                    Main.rand.Next(new int[] { BuffID.OnFire, BuffID.Electrified, BuffID.Frostburn, BuffID.Poisoned, ModContent.BuffType<BonedDebuff>(), BuffID.Stinky });
                target.AddBuff(buffToAdd, timeToDebuff);
            }
        }
    }
}
