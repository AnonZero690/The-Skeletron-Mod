using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.Common.Utils;

namespace TheSkeletronMod.Content.Items.Weapons.Calcium.CalcMelee
{
    internal class BoneBasher : ModItem
    {
        public override void SetDefaults()
        {
            Item.ItemDefaultMeleeShootProjectile(10, 10, 30, 1, 10, 10, ItemUseStyleID.Shoot, ModContent.ProjectileType<BoneBasherProjectile>(), 10, false);
            Item.DamageType = ModContent.GetInstance<Bonecursed>();
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.value = 12000;
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[ModContent.ProjectileType<BoneBasherProjectile>()] < 1;
        }
    }
    internal class BoneBasherProjectile : ModProjectile
    {
        public override string Texture => SkeletronUtils.GetEntityTexture<BoneBasher>();
        const int TimeLeftForReal = 9999;
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 5;
            ProjectileID.Sets.TrailingMode[Type] = 2;
        }
        public override void SetDefaults()
        {
            Projectile.width = 63; Projectile.height = 65;
            Projectile.friendly = true;
            Projectile.timeLeft = TimeLeftForReal;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
        }
        Player player;
        int direction = 0;
        public override void AI()
        {
            if (Projectile.timeLeft == TimeLeftForReal)
            {
                player = Main.player[Projectile.owner];
                Projectile.velocity = Projectile.velocity.SafeNormalize(Vector2.Zero);
                direction = Projectile.velocity.X > 0 ? 1 : -1;
                Projectile.spriteDirection = Projectile.velocity.X > 0 ? 1 : -1;
                player.heldProj = Projectile.whoAmI;
            }
            if (Main.mouseLeft)
            {
                float rotation = (Main.MouseWorld - player.Center).ToRotation();
                float rotational = Projectile.rotation - MathHelper.PiOver4 - MathHelper.PiOver2;
                Projectile.rotation = MathHelper.PiOver4 + rotation;
                if(direction == -1)
                {
                    rotational -= MathHelper.PiOver2;
                    Projectile.rotation += MathHelper.PiOver2;
                }
                Projectile.Center = player.Center.IgnoreTilePositionOFFSET(Vector2.UnitX.RotatedBy(rotation), 50);
                player.compositeFrontArm = new Player.CompositeArmData(true, Player.CompositeArmStretchAmount.Full, rotational);
                Projectile.timeLeft = TimeLeftForReal - 10;
            }
            else
            {
                Projectile.Kill();
            }
        }
        public override void ModifyDamageHitbox(ref Rectangle hitbox)
        {
            Vector2 handPos = Vector2.UnitY.RotatedBy(player.compositeFrontArm.rotation);
            float length = new Vector2(Projectile.width, Projectile.height).Length() * player.GetAdjustedItemScale(player.HeldItem);
            Vector2 endPos = handPos;
            Vector2 offsetVector = handPos * 4 - handPos;
            endPos *= length;
            handPos += player.MountedCenter + offsetVector;
            endPos += player.MountedCenter + offsetVector;
            (int X1, int X2) XVals = SkeletronUtils.Order(handPos.X, endPos.X);
            (int Y1, int Y2) YVals = SkeletronUtils.Order(handPos.Y, endPos.Y);
            hitbox = new Rectangle(XVals.X1 - 2, YVals.Y1 - 2, XVals.X2 - XVals.X1 + 2, YVals.Y2 - YVals.Y1 + 2);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Projectile.ProjectileDefaultDrawInfo(out Texture2D texture, out Vector2 origin);
            //The utils code do not support custom sprite direction so yea, or rather I just outright don't do it
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + origin + new Vector2(0f, Projectile.gfxOffY);
                Color color = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                Main.EntitySpriteDraw(texture, drawPos, null, color, Projectile.oldRot[k], origin, Projectile.scale, direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0);
            }
            return base.PreDraw(ref lightColor);
        }
    }
}
