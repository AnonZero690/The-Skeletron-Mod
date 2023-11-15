using Terraria;
using Terraria.ModLoader;

namespace TheSkeletronMod.Content.Buffs
{
    public class DeadlySkull : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
        }
        
    }
}
