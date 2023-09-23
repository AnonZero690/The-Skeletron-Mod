using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
using TheSkeletronMod.projectiles;
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
