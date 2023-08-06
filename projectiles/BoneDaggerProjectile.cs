using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace TheSkeletronMod.Projectiles
{
	public class BoneDaggerProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
            Projectile.width = 8;
            Projectile.height = 8;

            Projectile.aiStyle = 1;

            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 600;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 1;
            Projectile.damage = 12;

            AIType = ProjectileID.BoneArrow;
        }
		
	}
}
