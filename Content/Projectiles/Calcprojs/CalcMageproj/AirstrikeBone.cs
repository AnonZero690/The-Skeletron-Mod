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
            Projectile.CloneDefaults(ProjectileID.BloodArrow);
        }
        public override void AI()
        {
           
        }
    }
}