using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Reflection.Emit;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Map;
using Terraria.ModLoader;
using TheSkeletronMod.Common.Systems;
using Mono.Cecil;
using static Terraria.ModLoader.PlayerDrawLayer;
using Terraria.DataStructures;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.Modplayer;
using TheSkeletronMod.Items.Weapons.Calcium.CalcMelee;

namespace TheSkeletronMod.projectiles.Calcprojs.CalcMeleeproj
{
    public class BoneHeld : ModProjectile
    {

        int d = 0;
        int speed = 0;
        int maximunCharge = 0;

        float x = 20f;
        float y = -0f;
        int dmg;

        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Projectile.width = 1;
            Projectile.height = 1;
            Projectile.DamageType = ModContent.GetInstance<Bonecursed>();
            Projectile.knockBack = 4;
            Projectile.ownerHitCheck = true;
            Projectile.friendly = true;
            Projectile.timeLeft = 600;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
        }

        public override bool? CanDamage()
        {
            return false;
        }

        public override void OnSpawn(IEntitySource source)
        {
            if (Main.LocalPlayer.direction == -1)
            {
                Projectile.velocity = new Vector2(-x, y);
            }
            if (Main.LocalPlayer.direction == 1)
            {
                Projectile.velocity = new Vector2(x, y);
            }

        }

        public void Charge(Player player)
        {
            float velocity = 0f;
            Vector2 d = (Main.MouseWorld - player.position).SafeNormalize(Vector2.UnitX);
            if (player.GetModPlayer<SkullModplayer>().cc < 10)
            {
                velocity = 3f;
            }
            if (player.GetModPlayer<SkullModplayer>().cc > 10 && player.GetModPlayer<SkullModplayer>().cc < 20)
            {
                velocity = 4f;
            }
            if (player.GetModPlayer<SkullModplayer>().cc > 20 && player.GetModPlayer<SkullModplayer>().cc < 30)
            {
                velocity = 5f;

            }
            if (player.GetModPlayer<SkullModplayer>().cc > 30 && player.GetModPlayer<SkullModplayer>().cc < 40)
            {
                velocity = 6f;
                Projectile.damage = dmg * 2;
            }
            if (player.GetModPlayer<SkullModplayer>().cc > 40 && player.GetModPlayer<SkullModplayer>().cc < 50)
            {
                velocity = 7f;
            }
            if (player.GetModPlayer<SkullModplayer>().cc > 50 && player.GetModPlayer<SkullModplayer>().cc < 60)
            {
                velocity = 8f;

            }
            if (player.GetModPlayer<SkullModplayer>().cc > 60 && player.GetModPlayer<SkullModplayer>().cc < 70)
            {
                velocity = 9f;
                Projectile.damage = dmg * 3;
            }
            if (player.GetModPlayer<SkullModplayer>().cc > 70 && player.GetModPlayer<SkullModplayer>().cc < 80)
            {
                velocity = 10f;

            }
            if (player.GetModPlayer<SkullModplayer>().cc > 80 && player.GetModPlayer<SkullModplayer>().cc < 90)
            {
                velocity = 11f;
            }
            if (player.GetModPlayer<SkullModplayer>().cc > 90 && player.GetModPlayer<SkullModplayer>().cc < 100)
            {
                velocity = 12f;
            }
            if (player.GetModPlayer<SkullModplayer>().cc >= 100)
            {
                velocity = 13f;
                Projectile.damage = dmg * 4;
            }
            SoundEngine.PlaySound(SoundID.Item1);
            for (int i = 0; i < 100; i++)
            {
                Vector2 speed = Main.rand.NextVector2CircularEdge(1f, 1f);
                Dust dust1 = Dust.NewDustPerfect(player.Center, DustID.Bone, speed * 8, Scale: 1.5f);
                dust1.noGravity = true;
            }
            SoundEngine.PlaySound(SoundID.DD2_SkeletonDeath);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, d * velocity, ModContent.ProjectileType<BoneDaggerProjectile>(), Projectile.damage, 6f, player.whoAmI);

        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            Projectile.velocity = Projectile.velocity.SafeNormalize(Vector2.Zero);
            d = Projectile.velocity.X > 0 ? 1 : -1;
            Projectile.spriteDirection = d;
            dmg = Projectile.damage;

            player.heldProj = Projectile.whoAmI;
            player.direction = d;

            float rotation = MathHelper.ToRadians(d * speed);
            Projectile.Center = player.MountedCenter + Projectile.velocity.RotatedBy(rotation) * 14f;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver4 + rotation;
            if (Projectile.spriteDirection == -1)
                Projectile.rotation += MathHelper.PiOver2;
            float rotational = Projectile.rotation - MathHelper.PiOver4 - MathHelper.PiOver2;
            if (Projectile.spriteDirection == -1)
                rotational -= MathHelper.PiOver2;

            player.compositeFrontArm = new Player.CompositeArmData(true, Player.CompositeArmStretchAmount.Full, rotational);

            maximunCharge++;
            speed -= 1;

            if (player.GetModPlayer<SkullModplayer>().cc == 30)
            {
                for (int i = 0; i < 100; i++)
                {
                    Vector2 speed = Main.rand.NextVector2CircularEdge(1f, 1f);
                    Dust dust1 = Dust.NewDustPerfect(player.Center, DustID.Bone, speed * 8, Scale: 1.5f);
                    dust1.noGravity = true;
                }
                SoundEngine.PlaySound(SoundID.NPCHit2);
            }
            if (player.GetModPlayer<SkullModplayer>().cc == 60)
            {
                for (int i = 0; i < 100; i++)
                {
                    Vector2 speed = Main.rand.NextVector2CircularEdge(1f, 1f);
                    Dust dust1 = Dust.NewDustPerfect(player.Center, DustID.Bone, speed * 8, Scale: 2f);
                    dust1.noGravity = true;
                }
                SoundEngine.PlaySound(SoundID.NPCDeath2);
            }
            if (player.GetModPlayer<SkullModplayer>().cc == 99)
            {
                for (int i = 0; i < 100; i++)
                {
                    Vector2 speed = Main.rand.NextVector2CircularEdge(1f, 1f);
                    Dust dust1 = Dust.NewDustPerfect(player.Center, DustID.Bone, speed * 8, Scale: 2.5f);
                    dust1.noGravity = true;
                }
                SoundEngine.PlaySound(SoundID.DD2_DarkMageSummonSkeleton);
            }
            if (player.GetModPlayer<SkullModplayer>().cc < 100)
            {
                player.GetModPlayer<SkullModplayer>().cc++;
            }
            else if (maximunCharge > 100)
            {
                player.GetModPlayer<Screenshake>().ScreenShake = 1;
            }
            player.GetModPlayer<SkullModplayer>().ShowChargeBar = true;
            if (maximunCharge >= 150)
            {
                Charge(player);
                Projectile.Kill();
            }


            if (Main.mouseRight == false)
            {
                Charge(player);
                Projectile.Kill();
            }

            bool stillInUse = Main.mouseRight == true && !player.noItems && !player.CCed && player.HeldItem.ModItem is BoneDagger;
            if (!stillInUse)
                Projectile.Kill();

        }

        public override void Kill(int timeLeft)
        {
            Player player = Main.player[Projectile.owner];

            player.GetModPlayer<SkullModplayer>().ShowChargeBar = false;
            player.GetModPlayer<SkullModplayer>().cc = 0;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Player player = Main.player[Projectile.owner];

            SpriteEffects spriteEffects = SpriteEffects.None;
            if (Projectile.spriteDirection == -1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }



            var texture = (Texture2D)ModContent.Request<Texture2D>(Texture);

            int frameHeight = texture.Height / Main.projFrames[Projectile.type];
            int startY = frameHeight * Projectile.frame;

            var sourceRectangle = new Rectangle(0, startY, texture.Width, frameHeight);
            Vector2 origin = sourceRectangle.Size() / 2f;

            Color drawColor = Projectile.GetAlpha(lightColor);
            Main.EntitySpriteDraw(texture,
                Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY),
                sourceRectangle, drawColor, Projectile.rotation, origin, Projectile.scale, spriteEffects, 0);

            return false;
        }

    }
}