using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using System;
namespace TheSkeletronMod.Buffs
{
    class BoneDaggerr : ModBuff
    {
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<BoneDaggerDebuff>().BoneDaggerDeb = true;
        }
    }

    public class BoneDaggerDebuff : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public bool BoneDaggerDeb;

        public override void ResetEffects(NPC npc)
        {
            BoneDaggerDeb = false;
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (BoneDaggerDeb)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }

                npc.lifeRegen -= 16;
            }

        }
    }
}