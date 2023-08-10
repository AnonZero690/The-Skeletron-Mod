using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TheSkeletronMod.Items.Ammo;
using System;
namespace TheSkeletronMod.projectiles
{
    class CartilageArmorSetMinion : ModProjectile
    {

        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.minion = true;
            Projectile.minionSlots = 0;
        }

        public override void AI()
        {
            Projectile.ai[0] = 0;
            if (Projectile.ai[0] == 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    Main.projectile[Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, new Vector2((float)Math.Cos(i * Math.PI / 2) * 10, (float)Math.Sin(i * Math.PI / 2) * 10), ProjectileID.FlaironBubble, 15, 3)].aiStyle=ProjAIStyleID.FlaironBubble;
                    Projectile.ai[0] = 20;
                }
            }
            else {
                Projectile.ai[0]--;
            }
            
        }
    }
}