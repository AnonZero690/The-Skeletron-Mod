using System;
using Terraria;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
namespace TheSkeletronMod.Buffs
{
    class OstropotosisBuff : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage<Bonecursed> () -= 0.5f;
            player.statDefense *= 0.5f;
        }
    }
}
