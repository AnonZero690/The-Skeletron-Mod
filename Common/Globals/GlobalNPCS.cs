using Terraria.ModLoader;
using Terraria;
using log4net.Appender;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using TheSkeletronMod.Items.Materials;

namespace TheSkeletronMod.Common.Globals
{
    public class GlobalNPCS : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            switch (npc.type)
            {
                case NPCID.Skeleton:
                case NPCID.ArmoredSkeleton:
                case NPCID.SkeletonArcher:
                case NPCID.SporeSkeleton:
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientBone>(), 2, 1, 3));
                    break;
                case NPCID.DoctorBones:
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientBone>(), 1, 1, 1));
                    break;
            }
        }
    }
}
