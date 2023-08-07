using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace TheSkeletronMod.Items.Weapons
{
    internal class TestITem : ModItem
    {
        public override string Texture => SkeletronUtils.GetVanillaTexture<Item>(ItemID.BreakerBlade);
        public override void SetDefaults()
        {
            Item.ItemDefaultMeleeShootCustomProjectile(10, 10, 9000, 1, 10, 10, ItemUseStyleID.Shoot, ModContent.ProjectileType<TestItemProjectile>(), 1, false);
            Item.noMelee = true;
            Item.noUseGraphic = true;
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[ModContent.ProjectileType<TestItemProjectile>()] < 1;
        }
    }
    class TestItemProjectile : ModProjectile
    {
        public override string Texture => SkeletronUtils.GetVanillaTexture<Item>(ItemID.BreakerBlade);
        const int TimeLeftForReal = 9999;
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
        int progressReverse = 0;
        public override void AI()
        {
            if (progress > MaxProgress)
            {
                player = Main.player[Projectile.owner];
                progress = MaxProgress;
                Projectile.velocity = Projectile.velocity.SafeNormalize(Vector2.Zero);
                direction = Projectile.velocity.X > 0 ? 1 : -1;
                Projectile.spriteDirection = direction;
            }
            player.heldProj = Projectile.whoAmI;
            player.direction = direction;
            if (Main.mouseLeft)
            {
                    acceleration += .1f;
                float rotation = MathHelper.ToRadians(progressReverse * acceleration);
                Projectile.Center = player.Center + Projectile.velocity.RotatedBy(rotation) * 70f;
                Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver4 + rotation;
                if (Projectile.spriteDirection == -1)
                    Projectile.rotation += MathHelper.PiOver2;
            }
            else
            {
                Projectile.Kill();
            }
            float rotational = Projectile.rotation - MathHelper.PiOver4 - MathHelper.PiOver2;
            if (Projectile.spriteDirection == -1)
                rotational -= MathHelper.PiOver2;
            player.compositeFrontArm = new Player.CompositeArmData(true, Player.CompositeArmStretchAmount.Full,rotational);

            progressReverse += 1 * direction;
        }
    }
}