using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TheSkeletronMod.Items.Weapons.Calcium;
using Terraria.ID;
using Terraria.Audio;
using Microsoft.CodeAnalysis;

namespace TheSkeletronMod.projectiles.Calcprojs.CalcMageproj
{
    
    public class ClonedSkull : ModProjectile
    {
        
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.Skull);
            AIType = ProjectileID.Skull;
            Projectile.height = 24;
            Projectile.width = 24;
            Projectile.ArmorPenetration = 4;
            Projectile.Size = new Vector2(24,24);
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 10;
        }
        public override string Texture => SkeletronUtils.GetVanillaTexture<Projectile>(ProjectileID.Skull);
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.OnFire, 500);
        }
    }
}