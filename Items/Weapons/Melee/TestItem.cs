using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TheSkeletronMod.Items.Materials;
using TheSkeletronMod.Tiles;

namespace TheSkeletronMod.Items.Weapons
{
    internal class TestItem : ModItem
    {
        public override string Texture => SkeletronUtils.GetVanillaTexture<Item>(ItemID.BreakerBlade);
        public override void SetDefaults()
        {
            Item.ItemDefaultMeleeShootCustomProjectile(10, 10, 30, 1, 10, 10, ItemUseStyleID.Shoot, ModContent.ProjectileType<TestItemProjectile>(), 1, false);
            Item.noMelee = true;
            Item.noUseGraphic = true;
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[ModContent.ProjectileType<TestItemProjectile>()] < 1;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AncientBone>(), 35);
            recipe.AddTile(ModContent.TileType<BoneAltar>());
            recipe.Register();
        }

    }
    class TestItemProjectile : ModProjectile
    {
        int originalDamage = 30; // Change the damage here
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
        int moveAmount = 0;

        public override void AI()
        {
            Projectile.damage = (int)(originalDamage * (acceleration / 15)); // if you change the max acceleration make sure you change it here too. (the number is the max)
            //yeah the damage variable doesn't do anything because I don't know how to change the projectile's damage from here smh
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
                if (acceleration < 15)
                {
                    acceleration += .1f;
                }
                float rotation = MathHelper.ToRadians(direction * moveAmount);
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
            player.compositeFrontArm = new Player.CompositeArmData(true, Player.CompositeArmStretchAmount.Full, rotational);
            moveAmount += (int)acceleration;
        }
    }
}