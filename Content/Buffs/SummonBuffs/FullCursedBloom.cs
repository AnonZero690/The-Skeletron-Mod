using Terraria;
using Terraria.ModLoader;
using TheSkeletronMod.Content.Projectiles.Calcprojs.CalcSummProj.BloominBones;

namespace TheSkeletronMod.Content.Buffs.SummonBuffs
{
    public class FullCursedBloom : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<BloomingBonesSProj>()] > 0)
            {
                player.buffTime[buffIndex] = 18000;
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
}
