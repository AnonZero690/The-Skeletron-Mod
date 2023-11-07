using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace TheSkeletronMod.NPCs.Enemies
{
    class UndeadHand : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[10];
        }
        public override void SetDefaults()
        {
            NPC.friendly = false;
            NPC.width = 24;
            NPC.height = 24;
            NPC.lifeMax = 25;
            NPC.damage = 15;
            NPC.defense = 4;
            NPC.value = 900f;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCHit2;
            NPC.aiStyle = NPCAIStyleID.Fighter;
        }
        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter++;
            NPC.frame.Y = (int)NPC.frameCounter / 10 * frameHeight;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldNight.Chance * 0.3f;
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            Item.NewItem(NPC.GetSource_FromThis(), NPC.getRect(), ModContent.ItemType<Items.Placeables.Block.CalciumOre>(), Main.rand.Next(0, 20));
        }
    }
}
