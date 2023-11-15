using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheSkeletronMod.Items.Weapons.Range;

namespace TheSkeletronMod.Items.Weapons
{
    internal class PointyBoneWeapon : ModItem
    {
        public override string Texture => SkeletronUtils.GetTheSameTextureAsEntity<AncientBoneDart>();
        public override void SetDefaults()
        {
            Item.width = Item.height = 24;
            Item.useTime = Item.useAnimation = 20;
            Item.damage = 30;
            Item.knockBack = 1;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = false;
            Item.channel = true;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<PointyBoneWeaponProjectile>();
            Item.shootSpeed = 1f;
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[ModContent.ProjectileType<PointyBoneWeaponProjectile>()] < 1 || player.GetModPlayer<TODOMergeThisPlayerIntoMainPlayer>().CanAttackNow;
        }
    }
    public class PointyBoneWeaponProjectile : ModProjectile
    {
        public override string Texture => SkeletronUtils.GetTheSameTextureAsEntity<AncientBoneDart>();
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 10;
            ProjectileID.Sets.TrailingMode[Type] = 2;
        }
        public override void SetDefaults()
        {
            Projectile.width = 18; Projectile.height = 36;
            Projectile.tileCollide = true;
            Projectile.friendly = true;
            Projectile.timeLeft = 9999;
            Projectile.penetrate = -1;
        }
        Player player;
        float percentageChargeUp = 0;
        int originalDamage = 0;
        bool isReleased = false;
        Vector2 towardMouse = Vector2.Zero;
        public override bool? CanDamage() => isReleased;
        public override void AI()
        {
            if (Projectile.timeLeft == 9999)
            {
                player = Main.player[Projectile.owner];
                originalDamage = Projectile.damage;
            }
            if (!player.active || player.dead)
                Projectile.Kill();
            if (Main.mouseLeft && !isReleased)
            {
                player.GetModPlayer<TODOMergeThisPlayerIntoMainPlayer>().CanAttackNow = false;
                towardMouse = Main.MouseWorld - player.Center;
                Projectile.Center = player.Center + towardMouse.SafeNormalize(Vector2.Zero) * 50;
                Projectile.rotation = towardMouse.ToRotation() + MathHelper.PiOver2;
                Projectile.damage = (int)MathHelper.Lerp(originalDamage, originalDamage * 2, percentageChargeUp);
                percentageChargeUp = Math.Clamp(percentageChargeUp + .01f, 0, 1f);
                if (percentageChargeUp == 1 && Projectile.ai[0] == 0)
                {
                    Projectile.ai[0]++;
                    for (int i = 0; i < 4; i++)
                    {
                        Vector2 Toward = Vector2.UnitX.RotatedBy(MathHelper.ToRadians(90 * i) + Projectile.rotation);
                        for (int l = 0; l < 50; l++)
                        {
                            float multiplier = Main.rand.NextFloat();
                            float scale = MathHelper.Lerp(1.1f, .1f, multiplier) + 1f;
                            float randomrotate = MathHelper.Lerp(50f, 1f, SkeletronUtils.InOutSine(multiplier));
                            int dust = Dust.NewDust(Projectile.Center, 0, 0, DustID.GemRuby, 0, 0, 0, Color.White, scale);
                            Main.dust[dust].velocity = Toward.RotatedByRandom(MathHelper.ToRadians(randomrotate)) * multiplier * 15;
                            Main.dust[dust].noGravity = true;
                            if (l % 3 == 0)
                            {
                                int dust2 = Dust.NewDust(Projectile.Center, 0, 0, DustID.GemRuby, 0, 0, 0, Color.White, scale);
                                Main.dust[dust2].velocity = Main.rand.NextVector2CircularEdge(10, 10);
                                Main.dust[dust2].noGravity = true;
                            }
                        }
                    }
                }
            }
            else if (Main.mouseLeftRelease || isReleased)
            {
                isReleased = true;
                if (Projectile.timeLeft > 150)
                {
                    if (percentageChargeUp == 1)
                        Projectile.damage *= 2;
                    player.GetModPlayer<TODOMergeThisPlayerIntoMainPlayer>().CanAttackNow = true;
                    Projectile.velocity = towardMouse.SafeNormalize(Vector2.Zero) * 20;
                    Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
                    Projectile.timeLeft = 150;
                }
                Projectile.alpha = (int)MathHelper.Lerp(255, 0, Projectile.timeLeft / 150f);
            }
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.damage -= (int)(Projectile.damage * .05f);
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Main.instance.LoadProjectile(Type);
            if (!isReleased)
            {
                Texture2D texture = ModContent.Request<Texture2D>(Texture).Value;
                Vector2 origin = texture.Size() * .5f;
                Vector2 drawpos = Projectile.Center - Main.screenPosition;
                for (int l = 0; l < MathHelper.Lerp(0, 5, percentageChargeUp); l++)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        Vector2 finaldrawPos = drawpos.IgnoreTilePositionOFFSET(Vector2.UnitY.RotatedBy(MathHelper.ToRadians(MathHelper.Lerp(0 + 90f * i, 270f + 90f * i, SkeletronUtils.InOutSine(percentageChargeUp)))), MathHelper.Lerp(180, 2, SkeletronUtils.InOutSine(percentageChargeUp)));
                        Main.EntitySpriteDraw(texture, finaldrawPos, null, new Color(255, 0, 0, 0), Projectile.rotation, origin, Projectile.scale, SpriteEffects.None);
                    }
                }
            }
            Projectile.DrawTrail(new Color(255, 255, 255, 50));
            return base.PreDraw(ref lightColor);
        }
    }
    public class TODOMergeThisPlayerIntoMainPlayer : ModPlayer
    {
        public bool CanAttackNow = true;
    }
}
