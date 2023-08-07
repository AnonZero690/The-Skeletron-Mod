using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TheSkeletronMod.Items.Weapons.Calcium;

namespace TheSkeletronMod.projectiles
{
    public class BoneDaggerProjectile : ModProjectile
    {
        public override string Texture => SkeletronUtils.GetTheSameTextureAsEntity<BoneDagger>();
        public override void SetDefaults()
        {
            Projectile.width = Projectile.height = 16;

            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 600;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
        }
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            Projectile.ai[1] = Projectile.velocity.X > 0 ? 1 : -1;
            if (Projectile.ai[0] > 0)
            {
                Projectile.penetrate = 1;
                Projectile.width = Projectile.height = 20;
                ThrowDaggerLogic();
                return;
            }
            ShortSwordLogic(player);
        }
        private void ThrowDaggerLogic()
        {
            Projectile.rotation += MathHelper.ToRadians(10 + Projectile.velocity.Length()) * Projectile.ai[1];
            Projectile.ai[0]++;
            if (Projectile.ai[0] > 20)
            {
                Projectile.velocity.X *= .98f;
                Projectile.velocity.Y += .5f;
            }
        }
        private void ShortSwordLogic(Player player)
        {
            player.heldProj = Projectile.whoAmI;
            int MaxProgress = player.itemAnimationMax;
            if (Projectile.timeLeft > MaxProgress)
            {
                Projectile.timeLeft = MaxProgress;
            }
            float progress;
            int MaxProgressHalf = (int)(MaxProgress * .5f);
            if (Projectile.timeLeft >= MaxProgressHalf)
                progress = (MaxProgress - Projectile.timeLeft) / (float)MaxProgressHalf;
            else
                progress = Projectile.timeLeft / (float)MaxProgressHalf;
            Projectile.velocity = Projectile.velocity.SafeNormalize(Vector2.Zero);
            Projectile.Center = player.Center + Projectile.velocity * MathHelper.SmoothStep(20, 30, progress);
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            Projectile.spriteDirection = (int)Projectile.ai[1];
        }
    }
}