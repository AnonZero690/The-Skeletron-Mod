using Terraria;
using Terraria.ModLoader;

namespace TheSkeletronMod.Buffs
{
    class BoneWandBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
        }
    }
}
