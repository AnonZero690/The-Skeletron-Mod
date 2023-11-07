using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace TheSkeletronMod.NPCs.TownNPCs
{
    [AutoloadHead]
    public class DetectiveNPC : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 25;

            NPCID.Sets.ExtraFramesCount[Type] = 9;
            NPCID.Sets.AttackFrameCount[Type] = 4;
            NPCID.Sets.DangerDetectRange[Type] = 700;
            NPCID.Sets.AttackType[Type] = 1;
            NPCID.Sets.AttackTime[Type] = 30;
            NPCID.Sets.AttackAverageChance[Type] = 7;
            NPCID.Sets.HatOffsetY[Type] = 4;
        }
        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true; 
            NPC.width = 11; 
            NPC.height = 25; 
            NPC.aiStyle = NPCAIStyleID.Passive; 
            NPC.damage = 10; 
            NPC.defense = 33; 
            NPC.lifeMax = 500; 
            NPC.HitSound = SoundID.NPCHit1; 
            NPC.DeathSound = SoundID.NPCDeath1; 
            NPC.knockBackResist = 1f;

            AnimationType = NPCID.ArmsDealer;
        }
    }
}
