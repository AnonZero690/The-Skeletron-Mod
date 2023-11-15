using Terraria;
using Terraria.ModLoader;

namespace TheSkeletronMod.Content.Buffs
{
    class BoneWandBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
        }
    }
}
