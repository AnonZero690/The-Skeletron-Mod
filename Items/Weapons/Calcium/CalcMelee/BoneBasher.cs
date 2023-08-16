using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.Enums;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
using Terraria.ID;
using Terraria;
using TheSkeletronMod.Common.Globals;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
//using System.Numerics;
using Microsoft.CodeAnalysis;
using static tModPorter.ProgressUpdate;
using TheSkeletronMod.Items.Weapons.Melee;
using Microsoft.Xna.Framework.Input;
using Terraria.Utilities.Terraria.Utilities;

namespace TheSkeletronMod.Items.Weapons.Calcium.CalcMelee
{
    internal class BoneBasher : ModItem
    {
        //public float swingDegree => 120;


        public override void SetDefaults()
        {
            Item.ItemDefaultMeleeShootCustomProjectile(10, 10, 30, 1, 10, 10, ItemUseStyleID.Shoot, ModContent.ProjectileType<BoneBasherProjectile>(), 1, false);
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
        int direction = 0;
        int originDmg = 0;
        bool AlreadyRelease = false;
        public override void AI()
        {

            player = Main.player[Projectile.owner];
            Projectile.velocity = Projectile.velocity.SafeNormalize(Vector2.Zero);
            if (Main.MouseWorld.X < 750)
            {
                direction = -1;
            }
            else
            {
                direction = 1;
            }
            originDmg = Projectile.damage;

            player.heldProj = Projectile.whoAmI;
            if (Main.mouseLeft && !AlreadyRelease)
            {
                float rotation = (Main.MouseWorld - player.position).SafeNormalize(Vector2.UnitX).SafeNormalize(Vector2.UnitY).ToRotation();
                Projectile.Center = player.Center + Projectile.velocity.RotatedBy(rotation) * 70f;
                Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver4 + rotation;
                if (Projectile.spriteDirection == -1)
                {
                    Projectile.rotation += MathHelper.PiOver2;
                }
                float rotational = Projectile.rotation - MathHelper.PiOver4 - MathHelper.PiOver2;
                if (Projectile.spriteDirection == -1)
                {
                    rotational -= MathHelper.PiOver2;
                }
                player.compositeFrontArm = new Player.CompositeArmData(true, Player.CompositeArmStretchAmount.Full, rotational);
            }
            else
            {
                Projectile.Kill();
            }
            if ((Projectile.velocity == Vector2.Zero) && ((player.Center - Projectile.Center).LengthSquared() < new Vector2(Projectile.width, Projectile.height).LengthSquared() * .5f || Projectile.damage <= 1))
            {
                Projectile.Kill();
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (Projectile.velocity != Vector2.Zero)
            {
                Projectile.position += Projectile.velocity;
                Projectile.Center.LookForHostileNPC(out List<NPC> npclist, 200);
                foreach (NPC npc in npclist)
                {
                    npc.StrikeNPC(npc.CalculateHitInfo(Projectile.damage, -(Projectile.Center.X > npc.Center.X).BoolOne(), false));
                    player.dpsDamage += Projectile.damage;
                }
                for (int i = 0; i < 200; i++)
                {
                    Vector2 pos = SkeletronUtils.SpawnRanPositionThatIsNotIntoTile(Projectile.Center, 200, 200);
                    Dust.NewDust(pos, 0, 0, DustID.Dirt);
                }
            }
            Projectile.velocity = Vector2.Zero;
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
