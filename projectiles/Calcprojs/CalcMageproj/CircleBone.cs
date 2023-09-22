using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace TheSkeletronMod.projectiles.Calcprojs.CalcMageproj
{
    public class CircleBone : ModProjectile
    {



        public override string Texture => SkeletronUtils.GetVanillaTexture<Item>(ItemID.Bone);
        const int TimeLeftForReal = 9999;
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 5;
            ProjectileID.Sets.TrailingMode[Type] = 2;
        }
        public override void SetDefaults()
        {
            Projectile.width = 80; Projectile.height = 92;
            Projectile.friendly = true;
            Projectile.timeLeft = TimeLeftForReal;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
        }
        Player player;
        float acceleration = 1;
        int MaxProgress = 360;
        int progress = TimeLeftForReal;
        int direction = 0;
        int moveAmount = 0;
        int originDmg = 0;
        bool AlreadyRelease = false;
        bool ActivateRetrieve = false;
        public override void AI()
        {
            if (progress > MaxProgress)
            {
                player = Main.player[Projectile.owner];
                progress = MaxProgress;
                Projectile.velocity = Projectile.velocity.SafeNormalize(Vector2.Zero);
                direction = Projectile.velocity.X > 0 ? 1 : -1;
                Projectile.spriteDirection = direction;
                originDmg = Projectile.damage;
            }
            player.heldProj = Projectile.whoAmI;
            Projectile.damage = (int)(originDmg * (acceleration / 15));
            player.direction = direction;
            if (acceleration < 15)
            {
                acceleration += .1f;
            }
            float rotation = MathHelper.ToRadians(direction * moveAmount);
            Projectile.Center = player.Center;// + Projectile.velocity.RotatedBy(rotation) * 70f;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver4 + rotation;
            if (Projectile.spriteDirection == -1)
            Projectile.rotation += MathHelper.PiOver2;
            float rotational = Projectile.rotation - MathHelper.PiOver4 - MathHelper.PiOver2;
            if (Projectile.spriteDirection == -1)
            rotational -= MathHelper.PiOver2;
            moveAmount += (int)acceleration;
        }
    }
}
