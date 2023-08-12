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
using TheSkeletronMod.Items.Weapons.Calcium;
using TheSkeletronMod.Common.Systems;
using Mono.Cecil;
using static Terraria.ModLoader.PlayerDrawLayer;
using System.Collections.Generic;
using static tModPorter.ProgressUpdate;
using Terraria.DataStructures;
using TheSkeletronMod.Common.DamageClasses;

namespace TheSkeletronMod.projectiles
{
    public class BoneSwingHeld : ModProjectile
    {
        int d = 0;
        int speed = 0;
        int maximunTurn = 0;

        bool turn = false;

        float x = 3f;
        float y = -19f;

        int direction = 0;

        public override void SetStaticDefaults()
        {
            
        }

        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 32;
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
            return true;
        }

        public override void OnSpawn(IEntitySource source)
        {
            if (Main.LocalPlayer.direction == -1)
            {
                Projectile.velocity = new Vector2(-4.9f, y);
            }
            if (Main.LocalPlayer.direction == 1)
            {
                Projectile.velocity = new Vector2(x, y);
            }

        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            Projectile.velocity = Projectile.velocity.SafeNormalize(Vector2.Zero);
            d = Projectile.velocity.X > 0 ? 1 : -1;
            Projectile.spriteDirection = d;

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

            if (maximunTurn < 12)
            {
                maximunTurn++;
                if (turn == false)
                {
                    speed += 16;
                }
                if (turn == true)
                {
                    speed -= 16;
                }

            }
            else if (maximunTurn >= 12)
            {
                direction = Projectile.spriteDirection;
                if (turn == true)
                {
                    turn = false;
                }
                else
                {
                    turn = true;
                }
                maximunTurn = 0;
                SoundEngine.PlaySound(SoundID.Item1);

            }


            if (player.channel == false)
            {
                Projectile.Kill();
            }

            bool stillInUse = player.channel == true && !player.noItems && !player.CCed && player.HeldItem.ModItem is BoneDagger;
            if (!stillInUse)
                Projectile.Kill();

        }


        public override bool PreDraw(ref Color lightColor)
        {
            Player player = Main.player[Projectile.owner];

            SpriteEffects spriteEffects = SpriteEffects.None;
            if (Projectile.spriteDirection == -1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
            if (turn == true)
            {
                if (direction == 1)
                {
                    spriteEffects = SpriteEffects.FlipHorizontally;
                }
                if (direction == -1)
                {
                    Projectile.spriteDirection = 1;
                }
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