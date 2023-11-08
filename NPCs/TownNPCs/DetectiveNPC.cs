using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Personalities;

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

            NPC.Happiness
                //.SetBiomeAffection<TaintedBiome>(AffectionLevel.Love) This doesnt exist yet.
                .SetBiomeAffection<SnowBiome>(AffectionLevel.Love)
                .SetBiomeAffection<ForestBiome>(AffectionLevel.Like)
                .SetBiomeAffection<UndergroundBiome>(AffectionLevel.Like)
                .SetBiomeAffection<OceanBiome>(AffectionLevel.Dislike)
                .SetBiomeAffection<HallowBiome>(AffectionLevel.Dislike)
                .SetBiomeAffection<DesertBiome>(AffectionLevel.Hate)
                .SetBiomeAffection<JungleBiome>(AffectionLevel.Hate)

                .SetNPCAffection(NPCID.Steampunker, AffectionLevel.Like)
                .SetNPCAffection(NPCID.Mechanic, AffectionLevel.Like)
                .SetNPCAffection(NPCID.ArmsDealer, AffectionLevel.Like)
                .SetNPCAffection(NPCID.Guide, AffectionLevel.Like)
                .SetNPCAffection(NPCID.DD2Bartender, AffectionLevel.Like)
                .SetNPCAffection(NPCID.GoblinTinkerer, AffectionLevel.Like)
                .SetNPCAffection(NPCID.Clothier, AffectionLevel.Like)
                .SetNPCAffection(NPCID.TaxCollector, AffectionLevel.Dislike)
                .SetNPCAffection(NPCID.Truffle, AffectionLevel.Dislike)
                .SetNPCAffection(NPCID.PartyGirl, AffectionLevel.Dislike)
                .SetNPCAffection(NPCID.Angler, AffectionLevel.Hate)
                .SetNPCAffection(NPCID.Pirate, AffectionLevel.Hate)
            ;
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
