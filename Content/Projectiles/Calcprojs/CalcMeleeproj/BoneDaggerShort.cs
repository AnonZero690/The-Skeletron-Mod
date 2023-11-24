using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.Utils;
using TheSkeletronMod.Content.Items.Weapons.Calcium.CalcMelee;

namespace TheSkeletronMod.Content.Projectiles.Calcprojs.CalcMeleeproj
{
    public class BoneDaggerShort : ModProjectile
    {
        public override string Texture => SkeletronUtils.GetEntityTexture<BoneDagger>();
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = ProjAIStyleID.ShortSword;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
        }
    }
}