using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.Common.Utils;
using TheSkeletronMod.Content.Projectiles.Calcprojs.OtherProj;

namespace TheSkeletronMod.Content.Projectiles.Calcprojs.CalcMageproj
{
    
    public class HugeAirstrikeBone : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.BoneArrow);
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.scale = 3f;
            Projectile.tileCollide = false;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = ModContent.GetInstance<Bonecursed>();
            Projectile.penetrate = -1;
            Projectile.timeLeft = 600;
        }
        public override void ModifyDamageHitbox(ref Rectangle hitbox)
        {
            
            int hitboxX = hitbox.X;
            int hitboxY = hitbox.Y;
            int hitboxWidth = hitbox.Width;
            int hitboxHeight = hitbox.Height;

            hitbox = new Rectangle(hitboxX, hitboxY, hitboxWidth * 3, hitboxHeight * 3);
        }

    }
}