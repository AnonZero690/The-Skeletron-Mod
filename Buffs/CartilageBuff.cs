using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
using TheSkeletronMod.projectiles;
namespace TheSkeletronMod.Buffs
{
    class CartilageBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            //Projectile.NewProjectile(player.GetSource_FromThis(), player.position, player.velocity, ModContent.ProjectileType<CartilageArmorSetMinion>(), 0, 0, player.whoAmI);
        }
    }
}
