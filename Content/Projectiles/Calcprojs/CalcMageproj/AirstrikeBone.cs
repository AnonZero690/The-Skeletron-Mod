using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.Utils;

namespace TheSkeletronMod.Content.Projectiles.Calcprojs.CalcMageproj
{
    
    public class AirstrikeBone : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.BoneArrow);
            Projectile.width = 100;
            Projectile.height = 100;
            Projectile.tileCollide = false;
            Projectile.friendly = true;
        }
        public override void AI()
        {
            float OGCursorPosY = Main.mouseY;

            if (Projectile.position.Y < OGCursorPosY)
            {
                Projectile.tileCollide = true;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return base.OnTileCollide(oldVelocity);
            // do something
        }
    }
}