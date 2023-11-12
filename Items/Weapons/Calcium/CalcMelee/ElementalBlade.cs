using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Buffs;
using TheSkeletronMod.Common.Globals;
using TheSkeletronMod.Common.DamageClasses;

namespace TheSkeletronMod.Items.Weapons.Calcium.CalcMelee
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
        int repeatTimes = 2;
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            int timeToDebuff = 100;
            if (hit.Crit == true)
            {
                timeToDebuff = 150;
            }
            for (repeatTimes = 0; repeatTimes < 2; repeatTimes++)
            {
                int randomNumber = Main.rand.Next(1,7);
                if (randomNumber == 1)
                {
                    target.AddBuff(BuffID.OnFire, timeToDebuff);
                }
                if (randomNumber == 2)
                {
                    target.AddBuff(BuffID.Electrified, timeToDebuff);
                }
                if (randomNumber == 3)
                {
                    target.AddBuff(BuffID.Frostburn, timeToDebuff);
                }
                if (randomNumber == 4)
                {
                    target.AddBuff(BuffID.Poisoned, timeToDebuff);
                }
                if (randomNumber == 5)
                {
                    target.AddBuff(ModContent.BuffType<BonedDebuff>(), timeToDebuff); //change this to dungeon curse when it is added
                }
                if (randomNumber == 6)
                {
                    target.AddBuff(BuffID.Stinky, timeToDebuff);
                }
            }
        }
    }
}
