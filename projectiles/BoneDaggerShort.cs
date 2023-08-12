using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Items.Weapons.Calcium;

namespace TheSkeletronMod.projectiles
{
    public class BoneDaggerShort : ModProjectile
    {
        public override string Texture => SkeletronUtils.GetTheSameTextureAsEntity<BoneDagger>();
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