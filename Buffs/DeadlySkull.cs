using Terraria;
using Terraria.ModLoader;

namespace TheSkeletronMod.Buffs
{
    public class DeadlySkull : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
        }
        
    }
}
