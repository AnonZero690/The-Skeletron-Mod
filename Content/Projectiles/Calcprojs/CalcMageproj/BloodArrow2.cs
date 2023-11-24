using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.Utils;

namespace TheSkeletronMod.Content.Projectiles.Calcprojs.CalcMageproj
{
    
    public class BloodArrow2 : ModProjectile
    {
        public override string Texture => SkeletronUtils.GetVanillaTexture<Projectile>(ProjectileID.BloodArrow);
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.BloodArrow);
            AIType = ProjectileID.BloodArrow;
        }
        public override void AI()
        {
            Dust.NewDustPerfect(Projectile.Center, DustID.Blood);
        }
    }
}